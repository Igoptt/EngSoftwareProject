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
        private readonly DatabaseManager _databaseManager;
        private TherapistDto _currentTherapist;
        private readonly AddPrescriptionFormHelper _prescriptionFormHelper;
        public AddPrescriptionForm(DatabaseManager databaseManager, TherapistDto currentTherapist)
        {
            _databaseManager = databaseManager;
            _currentTherapist = currentTherapist;
            _prescriptionFormHelper = new AddPrescriptionFormHelper();


            var medicines = _databaseManager.GetAllMedicines();
            var exercises = _databaseManager.GetAllExercises();
            var treatments = _databaseManager.GetAllTreatments();
            
            InitializeComponent();
            
            //para popular a combo box das sessões
            foreach (var session in currentTherapist.TherapistSessions)
            {
                if (session.SessionPrescriptionId == -1)
                {
                    cb_ChooseSession.Items.Add($"Id da Sessão:{session.Id}: horario da sessão: {session.SessionDate}");
                }
                
            }
            //para popular as combo boxes com os varios serviços
            foreach (var medicine in medicines)
            {
                cb_Medicines.Items.Add($"Id:{medicine.Id}: Medicamento: {medicine.Name}, Dose: {medicine.Dosage}, Quando tomar: {medicine.TimeOfDayToTakeMedicine}");
            }
            
            foreach (var exercise in exercises)
            {
                cb_Exercises.Items.Add($"Id:{exercise.Id}: Exercício: {exercise.Name}, Intensidade: {exercise.Intensity}, Horário sugerido: {exercise.SuggestedSchedule}");
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
                        var medicineDto = _databaseManager.GetMedicineFromDb(Convert.ToInt32(chosenMedicineId)).MapToMedicineDto();
                        prescriptionServices.Add(medicineDto);
                    }

                    if (exerciseChosen)
                    {
                        var chosenExerciseId = cb_Exercises.Text.Split(':')[1];
                        var exerciseDto = _databaseManager.GetExerciseFromDb(Convert.ToInt32(chosenExerciseId)).MapToExerciseDto();
                        prescriptionServices.Add(exerciseDto);
                    }

                    if (treatmentChosen)
                    {
                        var chosenTreatmentId = cb_Treatments.Text.Split(':')[1];
                        var treatmentDto = _databaseManager.GetTreatmentFromDb(Convert.ToInt32(chosenTreatmentId)).MapToTreatmentDto();
                        prescriptionServices.Add(treatmentDto);
                    }
                    
                    //vai buscar a sessão á Bd atraves do seu Id
                    var chosenSessionId = cb_ChooseSession.Text.Split(':')[1];
                    var chosenSession = _databaseManager.GetSpecificSession(Convert.ToInt32(chosenSessionId)).MapToSessionToDto();
                    var chosenSessionClient = _databaseManager.GetSpecificClient(chosenSession.AssignedClientId).MapToClientDto();
                    
                    //cria a nova prescrição e adiciona á Bd
                    var newPrescription = _prescriptionFormHelper.CreatePrescription(chosenSessionClient.Id,_currentTherapist.Id,prescriptionServices);
                    var newPrescriptionDb = newPrescription.MapToPrescriptionDb();

                    var newPrescriptionDbId = _databaseManager.InsertNewPrescription(newPrescriptionDb);
                    newPrescription.Id = newPrescriptionDbId;
                    
                    //Atualiza a sessão para ter o Id da prescrição criada
                    chosenSession.SessionPrescriptionId = newPrescriptionDbId;
                    var chosenSessionDb = chosenSession.MapToSessionsDb();

                    var updatedSession = _databaseManager.UpdateSession(chosenSessionDb);
                    _currentTherapist.TherapistPrescriptions.Add(newPrescription);
                    var updatedTherapistDb = _currentTherapist.MapToTherapistDb();

                    var updateTherapist = _databaseManager.UpdateTherapist(updatedTherapistDb);
                    
                    if (updatedSession == 0) //falhou o update
                    {
                        MessageBox.Show("Ocorreu um erro ao adicionar esta prescrição à sessão. Por favor tente novamente.");
                    }
                    else
                    {
                        MessageBox.Show(@"Prescrição adicionada");
                        var form = new TherapistViewForm(_databaseManager, _currentTherapist.Id);
                        form.Show();
                        this.Close();
                    }
                }
                else //quando escolhe a sessão mas nao escolhe nenhum serviço
                {
                    MessageBox.Show("Escolha um dos serviços para adicionar! \n Caso não tenha nenhum serviço, por favor crie um.");
                }
            }
            else //quando tenta criar prescrição sem escolher a sessão
            {
                MessageBox.Show("Por favor escolha uma sessão para adicionar a prescrição.");
            }
        }

        private void btn_CreateService_Click(object sender, EventArgs e)
        {
            var form = new CreateServiceForm(_databaseManager,_currentTherapist);
            form.Show();
            Close();
        }
    }
}