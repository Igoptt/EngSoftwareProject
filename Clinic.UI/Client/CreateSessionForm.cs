using System;
using System.Windows.Forms;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Clinic.UI.FormHelpers;

namespace Clinic.UI
{
    public partial class CreateSessionForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private  ClientDto _clientDto;
        private readonly CreateSessionFormHelper _createSessionFormHelper;
        public CreateSessionForm(DatabaseManager databaseManager, ClientDto clientDto)
        {
            _databaseManager = databaseManager;
            _clientDto = clientDto;
            _createSessionFormHelper = new CreateSessionFormHelper();
            var clinicTherapists = _databaseManager.GetAllTherapists();
            
            InitializeComponent();

            foreach (var therapist in clinicTherapists)
            {
                cb_ChooseTherapist.Items.Add($"Id: {therapist.Id} {therapist.FirstName} {therapist.LastName}");
            }
            cb_sessionHours.Items.AddRange(new []{"9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00"});
        }

        private void btn_CreateSession_Click(object sender, EventArgs e)
        {
            
            var selectedTime = Convert.ToDateTime(dtp_SessionDate.Text);
            
            if (cb_ChooseTherapist.SelectedIndex > -1 && cb_sessionHours.SelectedIndex > -1 && (selectedTime >= DateTime.Now))
            {
                var chosenTherapist = cb_ChooseTherapist.Text.Split(' ');
                var chosenTherapistId = chosenTherapist[1];
                
                var chosenTherapistBd = _databaseManager.GetSpecificTherapistDb(Convert.ToInt32(chosenTherapistId));
                var chosenTherapistSessions = _databaseManager.GetTherapistSessions(chosenTherapistBd.Id).MapSessionsToDto();

                var session = _createSessionFormHelper.CreateSession(cb_sessionHours.Text, selectedTime, _clientDto.Id, chosenTherapistBd.Id);
                var therapistAvailable = _createSessionFormHelper.IsAvailable(session.SessionDate, chosenTherapistSessions);
                var clientAvailable = _createSessionFormHelper.IsAvailable(session.SessionDate, _clientDto.ClientAppointments);

                if (!therapistAvailable && !clientAvailable)
                {
                    MessageBox.Show(@"Este terapeuta esta ocupado na data e hora escolhidos");
                }
                else
                {
                    var sessionDb = session.MapToSessionsDb();
                    var sessionId = _databaseManager.InsertNewSession(sessionDb);
                    if (sessionId != 0) //quando consegue criar a sessão
                    {
                        sessionDb.Id = sessionId;
                        session.Id = sessionId;
                        
                        //Inicialmente era feito com o clientDto mas é mais rapido e facil usar o da Db pois tem menos lugares onde pode errar
                        
                        var currentClient = _databaseManager.GetSpecificClient(_clientDto.Id);
                        currentClient.ClientAppointments.Add(sessionId);
                        var updatedClient = _databaseManager.UpdateClient(currentClient);
                        if (updatedClient != 0) //quando consegue adicionar a sessão à lista do cliente
                        {
                            chosenTherapistBd.TherapistSessions.Add(sessionId);
                            var updatedTherapist = _databaseManager.UpdateTherapist(chosenTherapistBd);
                            MessageBox.Show(@"Sessão Marcada");
                            if (updatedTherapist != 0) //quando consegue adicionar a sessão à lista do terapeuta
                            {
                                var form = new ClientViewForm(_databaseManager, _clientDto.Id);
                                form.Show();
                                this.Close(); 
                            }
                            else
                            {
                                MessageBox.Show(@"Ocorreu um erro ao criar a sessã tente novamente!");
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"Ocorreu um erro ao criar a sessão tente novamente");
                        }
                    }
                    else //caso de erro ao acrescentar a BD
                    {
                        MessageBox.Show(@"Ocorreu um erro ao criar esta sessao! Por favor tente novamente");
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Precisa de escolher a data,hora e o Terapeuta! A data tem de ser a partir de amanha");
            }
        }
    }
}