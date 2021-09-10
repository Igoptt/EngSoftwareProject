﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Clinic.UI.FormHelpers;

namespace Clinic.UI
{
    public partial class AddPrescriptionForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly int _currentTherapistId;
        private readonly AddPrescriptionFormHelper _prescriptionFormHelper;
        public AddPrescriptionForm(UnitOfWork unitOfWork, int currentTherapistId)
        {
            _unitOfWork = unitOfWork;
            _currentTherapistId = currentTherapistId;
            _prescriptionFormHelper = new AddPrescriptionFormHelper();
            
            //TODO por isto num helper
            var therapistDb = _unitOfWork.TherapistRepository.GetTherapistById(_currentTherapistId);
            var therapistDbSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(_currentTherapistId);
            var therapistDbPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsEmmitedCByTherapist(_currentTherapistId);
            var currentTherapist = therapistDb.MapToTherapistDto();
            currentTherapist.TherapistPrescriptions = therapistDbPrescriptions.MapPrescriptionsToDto();
            currentTherapist.TherapistSessions = therapistDbSessions.MapSessionsToDto();

            var medicines = _unitOfWork.MedicinesRepository.GetAll();
            var exercises = _unitOfWork.ExercisesRepository.GetAll();
            var treatments = _unitOfWork.TreatmentsRepository.GetAll();
            
            
            InitializeComponent();

            foreach (var session in currentTherapist.TherapistSessions)
            {
                if (session.SessionPrescriptionId == -1)
                {
                    cb_ChooseSession.Items.Add($"Id da Sessão:{session.Id}: horario da sessão: {session.SessionDate}");
                }
                
            }

            foreach (var medicine in medicines)
            {
                cb_Medicines.Items.Add($"Id:{medicine.Id}: Medicamento: {medicine.Name}, Dose: {medicine.Dosage}, Quando tomar: {medicine.TimeOfDayToTakeMedicine}");
            }
            
            foreach (var exercise in exercises)
            {
                cb_Exercises.Items.Add($"Id:{exercise.Id}: Exercicio: {exercise.Name}, Intensidade: {exercise.Intensity}, Horario sugerido: {exercise.SuggestedSchedule}");
            }
            
            foreach (var treatment in treatments)
            {
                cb_Treatments.Items.Add($"Id:{treatment.Id}: Tratamento: {treatment.Name}, Tipo: {treatment.Type}, Duração: {treatment.Duration}");
            }
            
            // grpBox_PrescriptionOptions.Visible = false;
        }

        private void cb_ChooseSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if (cb_ChooseSession.SelectedIndex > -1)
            // {
            //     // grpBox_PrescriptionOptions.Visible = true;
            // }
        }
        private void cb_Services_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_SavePrescription_Click(object sender, EventArgs e)
        {
            if (cb_ChooseSession.SelectedIndex > -1)
            {
                var medicineChosen = _prescriptionFormHelper.ServiceChosen(cb_Medicines);
                var exerciseChosen = _prescriptionFormHelper.ServiceChosen(cb_Exercises);
                var treatmentChosen = _prescriptionFormHelper.ServiceChosen(cb_Treatments);
                
                if (medicineChosen || exerciseChosen || treatmentChosen)
                {
                    var prescriptionServices = new List<ServiceDto>();
                    if (medicineChosen)
                    {
                        var chosenMedicineId = cb_Medicines.Text.Split(':')[1];
                        var medicineDto = _unitOfWork.MedicinesRepository.GetMedicineById(Convert.ToInt32(chosenMedicineId)).MapToMedicineDto();
                        prescriptionServices.Add(medicineDto);
                    }

                    if (exerciseChosen)
                    {
                        var chosenExerciseId = cb_Exercises.Text.Split(':')[1];
                        var exerciseDto = _unitOfWork.ExercisesRepository.GetExerciseById(Convert.ToInt32(chosenExerciseId)).MapToExerciseDto();
                        prescriptionServices.Add(exerciseDto);
                    }

                    if (treatmentChosen)
                    {
                        var chosenTreatmentId = cb_Treatments.Text.Split(':')[1];
                        var treatmentDto = _unitOfWork.TreatmentsRepository.GetTreatmentById(Convert.ToInt32(chosenTreatmentId)).MapToTreatmentDto();
                        prescriptionServices.Add(treatmentDto);
                    }
                    
                    var chosenSessionId = cb_ChooseSession.Text.Split(':')[1];
                    var chosenSession = _unitOfWork.SessionsRepository.GetSessionById(Convert.ToInt32(chosenSessionId)).MapToSessionsDto();
                    var chosenSessionClientId = _unitOfWork.ClientRepository.GetClientById(chosenSession.AssignedClientId).MapToClientDto().Id;
                    
                    var newPrescription = _prescriptionFormHelper.CreatePrescription(chosenSessionClientId,_currentTherapistId,prescriptionServices);
                    var newPrescriptionDb = newPrescription.MapToPrescriptionDb();
                    var newPrescriptionDbId = _unitOfWork.PrescriptionsRepository.Insert(newPrescriptionDb);
                    
                    chosenSession.SessionPrescriptionId = newPrescriptionDbId;
                    var chosenSessionDb = chosenSession.MapToSessionsDb();
                    var updatedSession = _unitOfWork.SessionsRepository.Update(chosenSessionDb);
                    
                    if (updatedSession == 0) //falhou o update
                    {
                        MessageBox.Show("Ocorreu um erro ao adicionar esta prescrição á sessao. Por favor tente novamente");
                    }
                    else
                    {
                        MessageBox.Show(@"Prescrição adicionada");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Escolha um dos serviços para adicionar! \n Caso nao tenha nenhum serviço por favor crie um.");
                }
            }
            else
            {
                MessageBox.Show("Por favor escolha uma sesão para adicionar a prescrição");
            }
        }

        private void btn_CreateService_Click(object sender, EventArgs e)
        {
            var form = new CreateServiceForm(_unitOfWork,_currentTherapistId);
            form.Show();
            this.Close();
        }


        
    }
}