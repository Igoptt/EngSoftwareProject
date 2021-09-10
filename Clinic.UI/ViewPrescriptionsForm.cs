using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class ClientPrescriptionsForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly int _currentTherapistId;
        private readonly TherapistDto _currentTherapist;
        public ClientPrescriptionsForm(UnitOfWork unitOfWork, int currentTherapistId)
        {
            _unitOfWork = unitOfWork;
            _currentTherapistId = currentTherapistId;
            var currentTherapistDb = _unitOfWork.TherapistRepository.GetTherapistById(_currentTherapistId);
            var emittedPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsEmmitedCByTherapist(currentTherapistDb.Id);
            var therapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(currentTherapistDb.Id);
            
            _currentTherapist = currentTherapistDb.MapToTherapistDto();
            _currentTherapist.TherapistPrescriptions = emittedPrescriptions.MapPrescriptionsToDto();
            
            //TODO por num helper e acabar
            int i = 0;
            foreach (var prescription in emittedPrescriptions)
            {
                
                foreach (var service in prescription.PrescribedServices)
                {
                    
                }

                i++;
            }
            
            
            _currentTherapist.TherapistSessions = therapistSessions.MapSessionsToDto();
            
            var emittedPrescriptionsSource = new BindingSource();
            emittedPrescriptionsSource.DataSource = _currentTherapist.TherapistPrescriptions;
            InitializeComponent();
            
            grid_EmitedPrescriptions.DataSource = emittedPrescriptionsSource;
            
        }

        private void grid_EmitedPrescriptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_EmitedPrescriptions.Columns[e.ColumnIndex].Name == "ChangePrescription")
            {
                var form = new ChangePrescriptionContentsForm();
                form.Show();
            }

            if (grid_EmitedPrescriptions.Columns[e.ColumnIndex].Name == "Mais")
            {
                //TODO mostrar a informação da sessao numa message box (quais os serviços dados) e os detalhes destes
                foreach (var prescription in _currentTherapist.TherapistPrescriptions)
                {
                    foreach (var service in prescription.PrescribedServices)
                    {
                        var selectedRowPrescriptionId = Convert.ToInt32(grid_EmitedPrescriptions.CurrentRow.Cells["Id"].Value);
                        if (service.Id == selectedRowPrescriptionId)
                        {
                            //TODO para preencher o array dos prescription services tenho q ir buscar a cada serviço o Id para conseguir ir buscar a Bd
                            var exerciseBd = _unitOfWork.ExercisesRepository.GetExerciseById(service.Id);
                            if (exerciseBd != null) // quer dizer que o tipo de serviço era um exercise
                            {
                                var exerciseDto = exerciseBd.MapToExerciseDto();
                                MessageBox.Show(
                                    $"Este serviço era um exercicio, chamadado de: {exerciseDto.Name}" +
                                    $" \n Tem uma intensidade de:{exerciseDto.Intensity}" +
                                    $" \n O horario sugerido para fazer este exercicio é: {exerciseDto.SuggestedSchedule}");
                                // return;
                            }

                            var medicineBd = _unitOfWork.MedicinesRepository.GetMedicineById(service.Id);
                            if (medicineBd != null)
                            {
                                var medicineDto = medicineBd.MapToMedicineDto();
                                MessageBox.Show(
                                    $"Este serviço era um medicamento, chamdado de: {medicineDto.Name}" +
                                    $" \n Tem uma dosagem de:{medicineDto.Dosage}" +
                                    $" \n O horario sugerido para tomar este medicamento é: {medicineDto.TimeOfDayToTakeMedicine}");
                                // return;
                            }
                            var treatmentBd = _unitOfWork.TreatmentsRepository.GetTreatmentById(service.Id);
                            if (treatmentBd != null)
                            {
                                var treatmentDto = treatmentBd.MapToTreatmentDto();
                                MessageBox.Show(
                                    $"Este serviço era um tratamento, chamdado de: {treatmentDto.Name}" +
                                    $" \n Era do tipo:{treatmentDto.Type}" +
                                    $" \n Este tratamento tem uma duração de: {treatmentDto.Duration}");
                                // return;
                            }
                        } 
                    }
                }
            }
        }
    }
}