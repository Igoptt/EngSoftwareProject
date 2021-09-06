using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Clinic.UI.FormHelpers;

namespace Clinic.UI
{
    public partial class EditSessionForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly int _clientId;
        private readonly int _sessionId;
        private readonly EditSessionFormHelper _editSessionFormHelper;
        private readonly CreateSessionFormHelper _createSessionFormHelper;
        public EditSessionForm(UnitOfWork unitOfWork, int clientId, int sessionId)
        {
            _unitOfWork = unitOfWork;
            _clientId = clientId;
            _sessionId = sessionId;
            _editSessionFormHelper = new EditSessionFormHelper();
            _createSessionFormHelper = new CreateSessionFormHelper();
            InitializeComponent();
            cb_SessionHours.Items.AddRange(new []{"9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00"});
        }

        private void btn_SaveSessionChanges_Click(object sender, EventArgs e)
        {
            
            var selectedTime = Convert.ToDateTime(dtp_SessionDate.Text);
            if (cb_SessionHours.SelectedIndex > -1 && (selectedTime >= DateTime.Now))
            {
                var selectedSession = _unitOfWork.SessionsRepository.GetSessionById(_sessionId).MapToSessionsDto();
                var selectedTherapist = _unitOfWork.TherapistRepository.GetTherapistById(selectedSession.AssignedTherapistId).Id;
                var selectedTherapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(selectedTherapist).MapSessionsToDto();
                
                var newSession = _editSessionFormHelper.UpdateSession(cb_SessionHours.Text, selectedTime, selectedSession);
                
                var therapistAvailable = _createSessionFormHelper.TherapistAvailable(newSession.SessionDate, selectedTherapistSessions);
                if (!therapistAvailable)
                {
                    MessageBox.Show("O seu terapeuta nao pode nesta hora");
                }
                else
                {
                    var newSessionDb = newSession.MapToSessionsDb();
                    var sessionId = _unitOfWork.SessionsRepository.Update(newSessionDb);
                    if (sessionId != 0)
                    {
                        MessageBox.Show("A sua consulta foi mudada para a data escolhida");
                        var form = new ClientViewForm(_unitOfWork, _clientId);
                        form.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao mudar a data da sua consulta");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor escolha a data e hora");
            }
        }
    }
}