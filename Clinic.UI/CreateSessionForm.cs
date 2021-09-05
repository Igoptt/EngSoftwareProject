using System;
using System.Windows.Forms;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class CreateSessionForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly int _clientId;
        public CreateSessionForm(UnitOfWork unitOfWork, int clientId)
        {
            _unitOfWork = unitOfWork;
            _clientId = clientId;
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
            //TODO verificação se o terapeuta escolhido nao tem sessoes nessa hora
            var selectedTime = Convert.ToDateTime(dtp_SessionDate.Text);
            if (cb_ChooseTherapist.SelectedIndex > -1 && cb_sessionHours.SelectedIndex > -1 && (selectedTime >= DateTime.Now))
            {
                var chosenTherapist = cb_ChooseTherapist.Text;
                var therapistName = chosenTherapist.Split(' ');
                var therapistFirstName = therapistName[0];
                var therapistLastName = therapistName[1];
                var chosenTherapistBd = _unitOfWork.TherapistRepository.GetTherapistByFullName(therapistFirstName, therapistLastName);
                var chosenTherapistId = chosenTherapistBd.Id;

                var chosenTherapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(chosenTherapistId).MapSessionsToDto();
                
                
                bool sessionDateTimeUnavailable = false;
                
                
                //marca sessao
                var sessao = new SessionsDto();
                sessao.AssignedClientId = _clientId;
                sessao.SessionDate = selectedTime;

                
                sessao.AssignedTherapistId = chosenTherapistId;
                sessao.SessionActivities = "";
                sessao.TheraphistSessionNote = "";
                //o id atribuido nao intressa so precisa de ter um para o mapper nao dar erro
                
                sessao.Id = 0;
                
                var chosenHour = cb_sessionHours.Text.Split(':');
                sessao.SessionDate = sessao.SessionDate.AddHours(Convert.ToInt32(chosenHour[0]));
                MessageBox.Show($"{sessao.SessionDate}");
                foreach (var session in chosenTherapistSessions)
                {
                    if (session.SessionDate == sessao.SessionDate)
                    {
                        sessionDateTimeUnavailable = true;
                    }
                }

                if (sessionDateTimeUnavailable)
                {
                    MessageBox.Show("Este terapeuta esta ocupado na data e hora escolhidos");
                }
                else
                {
                    var sessionDb = sessao.MapToSessionsDb();
                    var sessionId = _unitOfWork.SessionsRepository.Insert(sessionDb);
                    if (sessionId != 0)
                    {
                        chosenTherapistBd.TherapistSessions.Add(sessionId);
                        _unitOfWork.TherapistRepository.Update(chosenTherapistBd);
                        MessageBox.Show(@"Sessão Marcada");
                        var form = new ClientViewForm(_unitOfWork, _clientId);
                        this.Close();
                    }
                    else
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