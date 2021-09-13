﻿using System;
using System.Windows.Forms;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class ClientViewForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private ClientDto _currentClient;
        private BindingSource clientSessions_Source;
        private BindingSource clientPrescriptions_Source;
        public ClientViewForm(UnitOfWork unitOfWork, int clientId)
        {
            _unitOfWork = unitOfWork;
            //TODO colocar isto num helper
            var clientDb = _unitOfWork.ClientRepository.GetClientById(clientId);
            _currentClient = clientDb.MapToClientDto();
            var currentClientSessions = _unitOfWork.SessionsRepository.GetClientSessions(clientId);
            var currentClientPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsByClient(clientId);
            _currentClient.ClientAppointments = currentClientSessions.MapSessionsToDto();
            _currentClient.ClientPrescriptions = currentClientPrescriptions.MapPrescriptionsToDto();
            
            //TODO por num helper
            int i = 0;
            foreach (var prescription in currentClientPrescriptions)
            {
                
                foreach (var service in prescription.PrescribedServices)
                {
                    var medicineDb = _unitOfWork.MedicinesRepository.GetMedicineById(service);
                    if (medicineDb != null)
                    {
                        _currentClient.ClientPrescriptions[i].PrescribedServices.Add(medicineDb.MapToMedicineDto());
                    }

                    var exerciseDb = _unitOfWork.ExercisesRepository.GetExerciseById(service);
                    if (exerciseDb != null)
                    {
                        _currentClient.ClientPrescriptions[i].PrescribedServices.Add(exerciseDb.MapToExerciseDto());
                    }

                    var treatmentDb = _unitOfWork.TreatmentsRepository.GetTreatmentById(service);
                    if (treatmentDb != null)
                    {
                        _currentClient.ClientPrescriptions[i].PrescribedServices.Add(treatmentDb.MapToTreatmentDto());
                    }
                }

                i++;
            }
            
            clientSessions_Source = new BindingSource();
            clientSessions_Source.DataSource = _currentClient.ClientAppointments;

            clientPrescriptions_Source = new BindingSource();
            clientPrescriptions_Source.DataSource = _currentClient.ClientPrescriptions;
            
            
            InitializeComponent();
            lb_ClientName.Text = $"{_currentClient.FirstName} {_currentClient.LastName}";
            grid_ClientSessions.DataSource = clientSessions_Source;
            grid_PrescriptionsClientView.DataSource = clientPrescriptions_Source;
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_PrescriptionsClientView.Columns[e.ColumnIndex].Name == "Mais")
            {
                //TODO por num helper
                foreach (var prescription in _currentClient.ClientPrescriptions)
                {
                    var selectedRowPrescriptionId = Convert.ToInt32(grid_PrescriptionsClientView.CurrentRow.Cells["Id"].Value);
                    
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
                // MessageBox.Show(@"A prescrição tem uma intensidade de X ao longo de Y dias");
            }
            else if (grid_PrescriptionsClientView.Columns[e.ColumnIndex].Name == "Visibilidade")
            {
                var selectedPrescriptionId = Convert.ToInt32(grid_PrescriptionsClientView.CurrentRow.Cells["Id"].Value);
                var form = new ChangePrescriptionVisibilityForm(_unitOfWork,_currentClient.Id,selectedPrescriptionId);
                form.Show();
            }
        }

        private void btn_CreateSessionClientView_Click(object sender, EventArgs e)
        {
            var form = new CreateSessionForm(_unitOfWork, _currentClient.Id);
            form.Show();
            this.Close();
        }


        private void grid_ClientSessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "DetalhesClientView")
            {
                var sessionTherapist = Convert.ToInt32(grid_ClientSessions.CurrentRow.Cells["AssignedTherapistId"].Value);
                var therapistDto = _unitOfWork.TherapistRepository.GetTherapistById(sessionTherapist).MapToTherapistDto();
                MessageBox.Show($"A sessão tem uma duração de 1 hora com o terapeuta {therapistDto.FirstName} {therapistDto.LastName} ");
            }
            else if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "EditarSessao")
            {
                //atualiza a sessao com este Id
                var selectedSessionId = Convert.ToInt32(grid_ClientSessions.CurrentRow.Cells["Id"].Value);
                var form = new EditSessionForm(_unitOfWork, _currentClient.Id, selectedSessionId);
                form.Show();
                this.Close();
            }
            else if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "DesmarcarClientView")
            {
                var confirmation= MessageBox.Show("Confirmção", "Tem a certeza que deseja desmarcar esta consulta?", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    var selectedRowId = Convert.ToInt32(grid_ClientSessions.CurrentRow.Cells["Id"].Value);
                    var sessionToDelete = _unitOfWork.SessionsRepository.GetSessionById(selectedRowId);
                    var sessionToDeleteDto = sessionToDelete.MapToSessionsDto();
                    if (sessionToDelete.SessionDate <= DateTime.Now)
                    {
                        MessageBox.Show("Esta consulta ja aconteceu");
                    }
                    else
                    {
                        var sessionClient = _unitOfWork.ClientRepository.GetClientById(_currentClient.Id);
                        var sessionTherapist = _unitOfWork.TherapistRepository.GetTherapistById(sessionToDelete.AssignedTherapistId);
                        sessionClient.ClientAppointments.Remove(sessionToDelete.Id);
                        _unitOfWork.ClientRepository.Update(sessionClient);
                        sessionTherapist.TherapistSessions.Remove(sessionToDelete.Id);
                        _unitOfWork.TherapistRepository.Update(sessionTherapist);
                        
                        var sessionDeleted = _unitOfWork.SessionsRepository.Delete(sessionToDelete);
                        if (sessionDeleted == 1)
                        {
                            var selectedRow = grid_ClientSessions.CurrentRow.Index;
                            MessageBox.Show(@"Sessao Desmarcada!");
                            grid_ClientSessions.Rows.RemoveAt(selectedRow);
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro ao desmarcar esta sessão. Tente novamente");
                        }
                    }
                }
            }
        }
    }
}