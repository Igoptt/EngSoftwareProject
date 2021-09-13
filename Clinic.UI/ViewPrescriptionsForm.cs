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
        private readonly UnitOfWork _unitOfWork;
        private readonly int _currentTherapistId;
        private readonly TherapistDto _currentTherapist;
        private List<Prescription> acessiblePrescriptions;
        public ClientPrescriptionsForm(UnitOfWork unitOfWork, int currentTherapistId)
        {
            _unitOfWork = unitOfWork;
            _currentTherapistId = currentTherapistId;
            acessiblePrescriptions = new List<Prescription>();
            
            var currentTherapistDb = _unitOfWork.TherapistRepository.GetTherapistById(_currentTherapistId);
            var emittedPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsEmmitedCByTherapist(currentTherapistDb.Id);
            var therapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(currentTherapistDb.Id);
            
            _currentTherapist = currentTherapistDb.MapToTherapistDto();
            _currentTherapist.TherapistPrescriptions = emittedPrescriptions.MapPrescriptionsToDto();
            
            //TODO por num helper
            int i = 0;
            foreach (var prescription in emittedPrescriptions)
            {
                
                foreach (var service in prescription.PrescribedServices)
                {
                    var medicineDb = _unitOfWork.MedicinesRepository.GetMedicineById(service);
                    if (medicineDb != null)
                    {
                        _currentTherapist.TherapistPrescriptions[i].PrescribedServices.Add(medicineDb.MapToMedicineDto());
                    }

                    var exerciseDb = _unitOfWork.ExercisesRepository.GetExerciseById(service);
                    if (exerciseDb != null)
                    {
                        _currentTherapist.TherapistPrescriptions[i].PrescribedServices.Add(exerciseDb.MapToExerciseDto());
                    }

                    var treatmentDb = _unitOfWork.TreatmentsRepository.GetTreatmentById(service);
                    if (treatmentDb != null)
                    {
                        _currentTherapist.TherapistPrescriptions[i].PrescribedServices.Add(treatmentDb.MapToTreatmentDto());
                    }
                }

                i++;
            }
            _currentTherapist.TherapistSessions = therapistSessions.MapSessionsToDto();

            var prescriptionsDb = _unitOfWork.PrescriptionsRepository.GetAll();
            
            foreach (var prescription in prescriptionsDb)
            {
                if (prescription.TherapistsWithAcess.Contains(_currentTherapist.Id))
                {
                    acessiblePrescriptions.Add(prescription);
                }
            }
            
            //Perde-se os serviços da prescrição aqui mas nao faz diferença pois so iremos mostrar a informação minima da prescrição
            //TODO implementar para nao se perder os serviços e ter o botão mais como tem para as emitidas
            var acessiblePrescriptionsDto = acessiblePrescriptions.MapPrescriptionsToDto();
            
            var emittedPrescriptionsSource = new BindingSource();
            emittedPrescriptionsSource.DataSource = _currentTherapist.TherapistPrescriptions;

            var acessiblePrescriptionsSource = new BindingSource();
            acessiblePrescriptionsSource.DataSource = acessiblePrescriptionsDto;
            InitializeComponent();
            
            grid_EmitedPrescriptions.DataSource = emittedPrescriptionsSource;
            grid_PrescriptionsWithClientGrantedAcess.DataSource = acessiblePrescriptionsDto;

        }

        private void grid_EmitedPrescriptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_EmitedPrescriptions.Columns[e.ColumnIndex].Name == "Mais")
            {
                //TODO mostrar a informação da sessao numa message box (quais os serviços dados) e os detalhes destes
                foreach (var prescription in _currentTherapist.TherapistPrescriptions)
                {
                    var selectedRowPrescriptionId = Convert.ToInt32(grid_EmitedPrescriptions.CurrentRow.Cells["Id"].Value);
                    
                    if (prescription.Id == selectedRowPrescriptionId)
                    {
                        var prescriptionDetails = "";
                        foreach (var service in prescription.PrescribedServices)
                        {
                            var exerciseBd = _unitOfWork.ExercisesRepository.GetExerciseById(service.Id);
                            if (exerciseBd != null) // quer dizer que o tipo de serviço era um exercise
                            {
                                var exerciseDto = exerciseBd.MapToExerciseDto();
                                prescriptionDetails +=
                                    $"Este serviço era um exercicio, chamadado de: {exerciseDto.Name}" +
                                    $" \n Tem uma intensidade de:{exerciseDto.Intensity}" +
                                    $" \n O horario sugerido para fazer este exercicio é: {exerciseDto.SuggestedSchedule} \n";
                            }

                            var medicineBd = _unitOfWork.MedicinesRepository.GetMedicineById(service.Id);
                            if (medicineBd != null)
                            {
                                var medicineDto = medicineBd.MapToMedicineDto();
                                prescriptionDetails +=$"Este serviço era um medicamento, chamdado de: {medicineDto.Name}" +
                                                      $" \n Tem uma dosagem de:{medicineDto.Dosage}" +
                                                      $" \n O horario sugerido para tomar este medicamento é: {medicineDto.TimeOfDayToTakeMedicine} \n";
                            }

                            var treatmentBd = _unitOfWork.TreatmentsRepository.GetTreatmentById(service.Id);
                            if (treatmentBd != null)
                            {
                                var treatmentDto = treatmentBd.MapToTreatmentDto();
                                prescriptionDetails +=
                                    $"Este serviço era um tratamento, chamdado de: {treatmentDto.Name}" +
                                    $" \n Era do tipo:{treatmentDto.Type}" +
                                    $" \n Este tratamento tem uma duração de: {treatmentDto.Duration} \n";
                            }
                        }
                        if (!string.IsNullOrEmpty(prescriptionDetails))
                        {
                            MessageBox.Show(prescriptionDetails);
                        }
                    }
                }
            }
        }

        private void grid_PrescriptionsWithClientGrantedAcess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_PrescriptionsWithClientGrantedAcess.Columns[e.ColumnIndex].Name == "More")
            {
                //TODO botao mais
            }
        }
    }
}