using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class TherapistViewForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private  TherapistDto _currentTherapist;
        public TherapistViewForm(UnitOfWork unitOfWork, int therapistId)
        {
            
            _unitOfWork = unitOfWork;
            
            //TODO meter isto num helper
            var therapistBd = _unitOfWork.TherapistRepository.GetTherapistById(therapistId);
            var therapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(therapistId);
            var therapistPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsCByTherapist(therapistId);
            _currentTherapist = therapistBd.MapToTherapistDto();
            _currentTherapist.TherapistPrescriptions = therapistPrescriptions.MapPrescriptionsToDto();
            _currentTherapist.TherapistSessions = therapistSessions.MapSessionsToDto();
            
            var therapistSessions_source = new BindingSource();
            therapistSessions_source.DataSource = _currentTherapist.TherapistSessions;
            
            
            InitializeComponent();
            grid_SessionsTherapistView.DataSource = therapistSessions_source;
            label_TherapistName.Text = $"{_currentTherapist.FirstName} {_currentTherapist.LastName}";
            //
            // grid_SessionsTherapistView.Rows.Add("Dia X", "Client Y");
            // grid_ClientsTherapistView.Rows.Add("Nome Y", "Sobrenome Z","Dia X");

        }

        private void btn_AddPrescriptionToSession_Click(object sender, EventArgs e)
        {
            var form = new AddPrescriptionForm();
            form.Show();
        }

        

        private void grid_ClientsTherapistView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_ClientsTherapistView.Columns[e.ColumnIndex].Name == "Prescrições")
            {
                //ir buscar as precrições daqele cliente para mostrar
                var form = new ClientPrescriptionsForm();
                form.Show();
            }
        }

        private void grid_SessionsTherapistView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_SessionsTherapistView.Columns[e.ColumnIndex].Name == "RemoveAppointmentTherapistView")
            {
                MessageBox.Show(@"Sessao Desmarcada");
            }
            if (grid_SessionsTherapistView.Columns[e.ColumnIndex].Name == "AddSessionNoteTherapistView")
            {
                MessageBox.Show(@"Nota Adicionada");
            }
        }
    }
}