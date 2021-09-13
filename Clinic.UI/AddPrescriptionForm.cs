using System;
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
        private TherapistDto currentTherapist;
        private readonly AddPrescriptionFormHelper _prescriptionFormHelper;
        public AddPrescriptionForm(UnitOfWork unitOfWork, int currentTherapistId)
        {
            _unitOfWork = unitOfWork;
            var _currentTherapistId = currentTherapistId;
            _prescriptionFormHelper = new AddPrescriptionFormHelper();
            
            //TODO por isto num helper
            var therapistDb = _unitOfWork.TherapistRepository.GetTherapistById(_currentTherapistId);
            var therapistDbSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(_currentTherapistId);
            var therapistDbPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsEmmitedCByTherapist(_currentTherapistId);
            currentTherapist = therapistDb.MapToTherapistDto();
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
                    
                    //vai buscar a sessão á Bd atraves do seu Id
                    var chosenSessionId = cb_ChooseSession.Text.Split(':')[1];
                    var chosenSession = _unitOfWork.SessionsRepository.GetSessionById(Convert.ToInt32(chosenSessionId)).MapToSessionsDto();
                    var chosenSessionClientId = _unitOfWork.ClientRepository.GetClientById(chosenSession.AssignedClientId).MapToClientDto().Id;
                    
                    //cria a nova prescrição e adiciona á Bd
                    var newPrescription = _prescriptionFormHelper.CreatePrescription(chosenSessionClientId,currentTherapist.Id,prescriptionServices);
                    var newPrescriptionDb = newPrescription.MapToPrescriptionDb();
                    var newPrescriptionDbId = _unitOfWork.PrescriptionsRepository.Insert(newPrescriptionDb);
                    newPrescription.Id = newPrescriptionDbId;
                    
                    //Atualiza a sessão para ter o Id da prescrição criada
                    chosenSession.SessionPrescriptionId = newPrescriptionDbId;
                    var chosenSessionDb = chosenSession.MapToSessionsDb();
                    var updatedSession = _unitOfWork.SessionsRepository.Update(chosenSessionDb);
                    currentTherapist.TherapistPrescriptions.Add(newPrescription);
                    var updatedTherapistDb = currentTherapist.MapToTherapistDb();
                    _unitOfWork.TherapistRepository.Update(updatedTherapistDb);
                    
                    if (updatedSession == 0) //falhou o update
                    {
                        MessageBox.Show("Ocorreu um erro ao adicionar esta prescrição á sessao. Por favor tente novamente");
                    }
                    else
                    {
                        MessageBox.Show(@"Prescrição adicionada");
                        var form = new TherapistViewForm(_unitOfWork, currentTherapist.Id);
                        form.Show();
                        this.Close();
                    }
                }
                else //quando escolhe a sessão mas nao escolhe nenhum serviço
                {
                    MessageBox.Show("Escolha um dos serviços para adicionar! \n Caso nao tenha nenhum serviço por favor crie um.");
                }
            }
            else //quando tenta criar prescrição sem escolher a sessão
            {
                MessageBox.Show("Por favor escolha uma sesão para adicionar a prescrição");
            }
        }

        private void btn_CreateService_Click(object sender, EventArgs e)
        {
            var form = new CreateServiceForm(_unitOfWork,currentTherapist.Id);
            form.Show();
            this.Close();
        }
    }
}