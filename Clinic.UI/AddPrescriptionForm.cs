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
            
            
            InitializeComponent();

            foreach (var session in currentTherapist.TherapistSessions)
            {
                cb_ChooseSession.Items.Add($"Id da Sessão:{session.Id}: horario da sessão: {session.SessionDate}");
            }

            grpBox_PrescriptionOptions.Visible = false;
        }

        private void cb_ChooseSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ChooseSession.SelectedIndex > -1)
            {
                grpBox_PrescriptionOptions.Visible = true;
            }
        }

        private void btn_SavePrescription_Click(object sender, EventArgs e)
        {
            var medicineDto = new MedicineDto();
            var treatmentDto = new TreatmentDto();
            var exerciseDto = new ExerciseDto();
            var prescriptionServices = new List<ServiceDto>();
            
            var createMedicine = _prescriptionFormHelper.MedicineFieldsFilled(textBox_MedicineName.Text, textBox_MedicineDosage.Text,textBox_MedicineSchedule.Text);
            var createExercise = _prescriptionFormHelper.ExerciseFieldsFilled(textBox_ExerciseName.Text,textBox_ExerciseIntensity.Text,textBox_SuggestedSchedule.Text);
            var createTreatment = _prescriptionFormHelper.TreatmentFieldsFilled(textBox_TreatmentName.Text, textBox_TreatmentType.Text, textBox_TreatmentDuration.Text);
            
            
            if (createMedicine || createExercise || createTreatment)
            {
                //TODO ver se posso por isto tudo em else ifs
                if (createMedicine)
                {
                    medicineDto = _prescriptionFormHelper.CreateMedicine(textBox_MedicineName.Text,textBox_MedicineDosage.Text,textBox_MedicineSchedule.Text);
                    var medicineDb = medicineDto.MapToMedicineDb();
                    var createdMedicineId = _unitOfWork.MedicinesRepository.Insert(medicineDb);
                    medicineDto.Id = createdMedicineId;
                    prescriptionServices.Add(medicineDto);
                }

                if (createExercise)
                {
                    exerciseDto = _prescriptionFormHelper.CreateExercise(textBox_ExerciseName.Text,textBox_ExerciseIntensity.Text,textBox_SuggestedSchedule.Text);
                    var exerciseDb = exerciseDto.MapToExerciseDb();
                    var createdExerciseId = _unitOfWork.ExercisesRepository.Insert(exerciseDb);
                    exerciseDto.Id = createdExerciseId;
                    prescriptionServices.Add(exerciseDto);
                }

                if (createTreatment)
                {
                    treatmentDto = _prescriptionFormHelper.CreateTreatment(textBox_TreatmentName.Text,textBox_TreatmentDuration.Text,textBox_TreatmentType.Text);
                    var treatmentDb = treatmentDto.MapToTreatmentDb();
                    var createdTreatmentId = _unitOfWork.TreatmentsRepository.Insert(treatmentDb);
                    treatmentDto.Id = createdTreatmentId;
                    prescriptionServices.Add(treatmentDto);
                }
                
                var chosenSessionId = cb_ChooseSession.Text.Split(':')[1];
                var chosenSession = _unitOfWork.SessionsRepository.GetSessionById(Convert.ToInt32(chosenSessionId)).MapToSessionsDto();
                var chosenSessionClientId = _unitOfWork.ClientRepository.GetClientById(chosenSession.AssignedClientId).MapToClientDto().Id;
                var newPrescription = _prescriptionFormHelper.CreatePrescription(chosenSessionClientId,_currentTherapistId,prescriptionServices);
                var newPrescriptionDb = newPrescription.MapToPrescriptionDb();
                var newPrescriptionDbId = _unitOfWork.PrescriptionsRepository.Insert(newPrescriptionDb);
                MessageBox.Show(@"Prescrição adicionada");
                this.Close();
            }
            else 
            {
                MessageBox.Show("Por favor preencha os campos para criar pelo menos um tipo de Serviço");
            }
            
        }
        
    }
}