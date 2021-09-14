using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class ClientPrescriptionsForm : Form
    {
        // private readonly UnitOfWork _unitOfWork;
        private readonly DatabaseManager _databaseManager;
        // private readonly int _currentTherapistId;
        private TherapistDto _currentTherapist;
        private List<Prescription> acessiblePrescriptions;
        private TherapistDto dummyTherapist;
        public ClientPrescriptionsForm(DatabaseManager databaseManager, TherapistDto currentTherapist)
        {
            // _unitOfWork = unitOfWork;
            _databaseManager = databaseManager;
            // _currentTherapistId = currentTherapistId;
            _currentTherapist = currentTherapist;
            acessiblePrescriptions = new List<Prescription>();
            
            // var currentTherapistDb = _unitOfWork.TherapistRepository.GetTherapistById(_currentTherapistId);
            // var emittedPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsEmmitedCByTherapist(currentTherapistDb.Id);
            // var therapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(currentTherapistDb.Id);
            //
            // _currentTherapist = currentTherapistDb.MapToTherapistDto();
            // _currentTherapist.TherapistPrescriptions = emittedPrescriptions.MapPrescriptionsToDto();
            
            // int i = 0;
            // foreach (var prescription in emittedPrescriptions)
            // {
            //     
            //     foreach (var service in prescription.PrescribedServices)
            //     {
            //         var medicineDb = _unitOfWork.MedicinesRepository.GetMedicineById(service);
            //         if (medicineDb != null)
            //         {
            //             _currentTherapist.TherapistPrescriptions[i].PrescribedServices.Add(medicineDb.MapToMedicineDto());
            //         }
            //
            //         var exerciseDb = _unitOfWork.ExercisesRepository.GetExerciseById(service);
            //         if (exerciseDb != null)
            //         {
            //             _currentTherapist.TherapistPrescriptions[i].PrescribedServices.Add(exerciseDb.MapToExerciseDto());
            //         }
            //
            //         var treatmentDb = _unitOfWork.TreatmentsRepository.GetTreatmentById(service);
            //         if (treatmentDb != null)
            //         {
            //             _currentTherapist.TherapistPrescriptions[i].PrescribedServices.Add(treatmentDb.MapToTreatmentDto());
            //         }
            //     }
            //
            //     i++;
            // }
            
            // _currentTherapist.TherapistSessions = therapistSessions.MapSessionsToDto();

            var prescriptionsDb = _databaseManager.GetAllPrescriptions();
            
            //este therapist apenas tem a lista das prescrições as quais tem acesso isto serve para nao ser necessario criar funções novas e poder reutilizar as existentes no Database Manager
            dummyTherapist = new TherapistDto();
            
            
            foreach (var prescription in prescriptionsDb)
            {
                if (prescription.TherapistsWithAcess.Contains(_currentTherapist.Id))
                {
                    acessiblePrescriptions.Add(prescription);
                }
            }
            
            dummyTherapist.TherapistPrescriptions = _databaseManager.TherapistPrescriptionsWithServicesDto(acessiblePrescriptions,dummyTherapist);
            // var acessiblePrescriptionsDto = acessiblePrescriptions.MapPrescriptionsToDto();
            
            var emittedPrescriptionsSource = new BindingSource();
            emittedPrescriptionsSource.DataSource = _currentTherapist.TherapistPrescriptions;

            var acessiblePrescriptionsSource = new BindingSource();
            acessiblePrescriptionsSource.DataSource = dummyTherapist.TherapistPrescriptions;
            InitializeComponent();
            
            grid_EmitedPrescriptions.DataSource = emittedPrescriptionsSource;
            grid_PrescriptionsWithClientGrantedAcess.DataSource = dummyTherapist.TherapistPrescriptions;

        }

        private void grid_EmitedPrescriptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_EmitedPrescriptions.Columns[e.ColumnIndex].Name == "Mais")
            {
                var selectedRowPrescriptionId = Convert.ToInt32(grid_EmitedPrescriptions.CurrentRow.Cells["Id"].Value);
                var prescriptionInformation = _databaseManager.GetPrescriptionServicesInformation(_currentTherapist.TherapistPrescriptions,selectedRowPrescriptionId);
                
                if (!string.IsNullOrEmpty(prescriptionInformation))
                {
                    MessageBox.Show(prescriptionInformation);
                }
                else
                {
                    MessageBox.Show(@"Nao foi encontrada informação acerca desta prescrição");
                }
                // foreach (var prescription in _currentTherapist.TherapistPrescriptions)
                // {
                //     if (prescription.Id == selectedRowPrescriptionId)
                //     {
                //         var prescriptionDetails = "";
                //         foreach (var service in prescription.PrescribedServices)
                //         {
                //             var exerciseBd = _unitOfWork.ExercisesRepository.GetExerciseById(service.Id);
                //             if (exerciseBd != null) // quer dizer que o tipo de serviço era um exercise
                //             {
                //                 var exerciseDto = exerciseBd.MapToExerciseDto();
                //                 prescriptionDetails +=
                //                     $"Este serviço era um exercicio, chamadado de: {exerciseDto.Name}" +
                //                     $" \n Tem uma intensidade de:{exerciseDto.Intensity}" +
                //                     $" \n O horario sugerido para fazer este exercicio é: {exerciseDto.SuggestedSchedule} \n";
                //             }
                //
                //             var medicineBd = _unitOfWork.MedicinesRepository.GetMedicineById(service.Id);
                //             if (medicineBd != null)
                //             {
                //                 var medicineDto = medicineBd.MapToMedicineDto();
                //                 prescriptionDetails +=$"Este serviço era um medicamento, chamdado de: {medicineDto.Name}" +
                //                                       $" \n Tem uma dosagem de:{medicineDto.Dosage}" +
                //                                       $" \n O horario sugerido para tomar este medicamento é: {medicineDto.TimeOfDayToTakeMedicine} \n";
                //             }
                //
                //             var treatmentBd = _unitOfWork.TreatmentsRepository.GetTreatmentById(service.Id);
                //             if (treatmentBd != null)
                //             {
                //                 var treatmentDto = treatmentBd.MapToTreatmentDto();
                //                 prescriptionDetails +=
                //                     $"Este serviço era um tratamento, chamdado de: {treatmentDto.Name}" +
                //                     $" \n Era do tipo:{treatmentDto.Type}" +
                //                     $" \n Este tratamento tem uma duração de: {treatmentDto.Duration} \n";
                //             }
                //         }
                //         if (!string.IsNullOrEmpty(prescriptionDetails))
                //         {
                //             MessageBox.Show(prescriptionDetails);
                //         }
                //     }
                // }
            }
        }

        private void grid_PrescriptionsWithClientGrantedAcess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_PrescriptionsWithClientGrantedAcess.Columns[e.ColumnIndex].Name == "More")
            {
                var selectedRowPrescriptionId = Convert.ToInt32(grid_PrescriptionsWithClientGrantedAcess.CurrentRow.Cells["Id"].Value);
                var prescriptionInformation = _databaseManager.GetPrescriptionServicesInformation(dummyTherapist.TherapistPrescriptions,selectedRowPrescriptionId);
                
                if (!string.IsNullOrEmpty(prescriptionInformation))
                {
                    MessageBox.Show(prescriptionInformation);
                }
                else
                {
                    MessageBox.Show(@"Nao foi encontrada informação acerca desta prescrição");
                }
            }
        }
        //
        // private void ClientPrescriptionsForm_Load(object sender, EventArgs e)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}