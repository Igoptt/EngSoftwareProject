using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class AddPrescriptionForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly int _currentTherapistId;
        public AddPrescriptionForm(UnitOfWork unitOfWork, int currentTherapistId)
        {
            _unitOfWork = unitOfWork;
            _currentTherapistId = currentTherapistId;
            
            //TODO por isto num helper
            var therapistDb = _unitOfWork.TherapistRepository.GetTherapistById(_currentTherapistId);
            var therapistDbSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(_currentTherapistId);
            var therapistDbPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsCByTherapist(_currentTherapistId);
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
            
            if (!string.IsNullOrEmpty(textBox_MedicineName.Text) &&
                !string.IsNullOrEmpty(textBox_MedicineDosage.Text) &&
                !string.IsNullOrEmpty(textBox_MedicineSchedule.Text))
            {
                medicineDto = new MedicineDto();
                medicineDto.Name = textBox_MedicineName.Text;
                medicineDto.Dosage = textBox_MedicineDosage.Text;
                medicineDto.TimeOfDayToTakeMedicine = textBox_MedicineSchedule.Text;
                medicineDto.Id = 0;
                var medicineDb = medicineDto.MapToMedicineDb();
                var createdMedicineId = _unitOfWork.MedicinesRepository.Insert(medicineDb);
                medicineDto.Id = createdMedicineId;
            }
            //TODO colocar isto num helper
            var chosenSessionId = cb_ChooseSession.Text.Split(':')[1];
            var chosenSession = _unitOfWork.SessionsRepository.GetSessionById(Convert.ToInt32(chosenSessionId)).MapToSessionsDto();
            var chosenSessionClientId = _unitOfWork.ClientRepository.GetClientById(chosenSession.AssignedClientId).MapToClientDto().Id;
            var newPrescription = new PrescriptionDto()
            {
                ClientId = chosenSessionClientId,
                PrescriptionAuthorId = _currentTherapistId,
                Id = 0,
            };
            newPrescription.PrescribedServices.Add(medicineDto);
            var newPrescriptionDb = newPrescription.MapToPrescriptionDb();
            var newPrescriptionDbId = _unitOfWork.PrescriptionsRepository.Insert(newPrescriptionDb);
            
            MessageBox.Show(@"Prescrição adicionada");
            this.Close();
        }
        
    }
}