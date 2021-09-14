using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Clinic.UI.FormHelpers;

namespace Clinic.UI
{
    public partial class EditSessionForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        // private readonly UnitOfWork _unitOfWork;
        // private readonly int _clientId;
        private ClientDto _clientDto;
        private readonly int _sessionId;
        private readonly EditSessionFormHelper _editSessionFormHelper;
        private readonly CreateSessionFormHelper _createSessionFormHelper;
        public EditSessionForm(DatabaseManager databaseManager, ClientDto clientDto, int sessionId)
        {
            // _unitOfWork = unitOfWork;
            _databaseManager = databaseManager;
            // _clientId = clientId;
            _clientDto = clientDto;
            _sessionId = sessionId;
            _editSessionFormHelper = new EditSessionFormHelper();
            _createSessionFormHelper = new CreateSessionFormHelper();
            InitializeComponent();
            cb_SessionHours.Items.AddRange(new []{"9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00"});
        }

        private void btn_SaveSessionChanges_Click(object sender, EventArgs e)
        {
            
            var selectedTime = Convert.ToDateTime(dtp_SessionDate.Text);
            if (cb_SessionHours.SelectedIndex > -1 && (selectedTime > DateTime.Now))
            {
                // var selectedSession = _unitOfWork.SessionsRepository.GetSessionById(_sessionId).MapToSessionToDto();
                // var selectedTherapist = _unitOfWork.TherapistRepository.GetTherapistById(selectedSession.AssignedTherapistId).Id;
                // var selectedTherapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(selectedTherapist).MapSessionsToDto();
                var selectedSession = _databaseManager.GetSpecificSession(_sessionId).MapToSessionToDto();
                var selectedTherapist = _databaseManager.GetSpecificTherapistDb(selectedSession.AssignedTherapistId).MapToTherapistDto();
                var selectedTherapistSessions = _databaseManager.GetTherapistSessions(selectedTherapist.Id).MapSessionsToDto();
                
                var newSession = _editSessionFormHelper.UpdateSession(cb_SessionHours.Text, selectedTime, selectedSession);
                
                var therapistAvailable = _createSessionFormHelper.IsAvailable(newSession.SessionDate, selectedTherapistSessions);
                var clientAvailable = _createSessionFormHelper.IsAvailable(newSession.SessionDate, _clientDto.ClientAppointments);
                if (!therapistAvailable && !clientAvailable)
                {
                    MessageBox.Show("O seu terapeuta nao pode nesta hora");
                }
                else
                {
                    var newSessionDb = newSession.MapToSessionsDb();
                    // var sessionId = _unitOfWork.SessionsRepository.Update(newSessionDb);
                    var sessionId = _databaseManager.UpdateSession(newSessionDb);
                    if (sessionId != 0)
                    {
                        MessageBox.Show("A sua consulta foi mudada para a data escolhida");
                        var form = new ClientViewForm(_databaseManager, _clientDto.Id);
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