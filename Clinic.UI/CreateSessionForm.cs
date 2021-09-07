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
        private readonly UnitOfWork _unitOfWork;
        private readonly int _clientId;
        private readonly CreateSessionFormHelper _createSessionFormHelper;
        public CreateSessionForm(UnitOfWork unitOfWork, int clientId)
        {
            _unitOfWork = unitOfWork;
            _clientId = clientId;
            _createSessionFormHelper = new CreateSessionFormHelper();
            var clinicTherapists = _unitOfWork.TherapistRepository.GetAll();
            
            InitializeComponent();

            foreach (var therapist in clinicTherapists)
            {
                cb_ChooseTherapist.Items.Add($"{therapist.FirstName} {therapist.LastName}");
            }
            cb_sessionHours.Items.AddRange(new []{"9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00"});
        }

        private void btn_CreateSession_Click(object sender, EventArgs e)
        {
            
            var selectedTime = Convert.ToDateTime(dtp_SessionDate.Text);
            if (cb_ChooseTherapist.SelectedIndex > -1 && cb_sessionHours.SelectedIndex > -1 && (selectedTime >= DateTime.Now))
            {
                //TODO ver se da para por estas 3 linhas no helper
                var chosenTherapist = cb_ChooseTherapist.Text.Split(' ');
                var therapistFirstName = chosenTherapist[0];
                var therapistLastName = chosenTherapist[1];
                
                var chosenTherapistBd = _unitOfWork.TherapistRepository.GetTherapistByFullName(therapistFirstName, therapistLastName);
                var chosenTherapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(chosenTherapistBd.Id).MapSessionsToDto();
                
                var sessao = _createSessionFormHelper.CreateSession(cb_sessionHours.Text, selectedTime, _clientId, chosenTherapistBd.Id);
                var therapistAvailable = _createSessionFormHelper.TherapistAvailable(sessao.SessionDate, chosenTherapistSessions);

                if (!therapistAvailable)
                {
                    MessageBox.Show("Este terapeuta esta ocupado na data e hora escolhidos");
                }
                else
                {
                    var sessionDb = sessao.MapToSessionsDb();
                    var sessionId = _unitOfWork.SessionsRepository.Insert(sessionDb);
                    if (sessionId != 0)
                    {
                        var currentClient = _unitOfWork.ClientRepository.GetClientById(_clientId);
                        currentClient.ClientAppointments.Add(sessionId);
                        _unitOfWork.ClientRepository.Update(currentClient);
                        chosenTherapistBd.TherapistSessions.Add(sessionId);
                        _unitOfWork.TherapistRepository.Update(chosenTherapistBd);
                        MessageBox.Show(@"Sessão Marcada");
                        var form = new ClientViewForm(_unitOfWork, _clientId);
                        form.Show();
                        this.Close();
                    }
                    else //caso de erro ao acrescentar a BD
                    {
                        MessageBox.Show("Ocorreu um erro ao criar esta sessao! Por favor tente novamente");
                    }
                }
            }
            else
            {
                MessageBox.Show("Precisa de escolher a data,hora e o Terapeuta! A data tem de ser a partir de amanha");
            }
        }
    }
}