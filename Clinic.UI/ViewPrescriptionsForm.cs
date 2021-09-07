using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class ClientPrescriptionsForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly int _currentTherapistId;
        public ClientPrescriptionsForm(UnitOfWork unitOfWork, int currentTherapistId)
        {
            _unitOfWork = unitOfWork;
            _currentTherapistId = currentTherapistId;
            var currentTherapistDb = _unitOfWork.TherapistRepository.GetTherapistById(_currentTherapistId);
            var emittedPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsEmmitedCByTherapist(currentTherapistDb.Id);
            var therapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(currentTherapistDb.Id);
            
            var currentTherapist = currentTherapistDb.MapToTherapistDto();
            currentTherapist.TherapistPrescriptions = emittedPrescriptions.MapPrescriptionsToDto();
            currentTherapist.TherapistSessions = therapistSessions.MapSessionsToDto();
            
            var emittedPrescriptionsSource = new BindingSource();
            emittedPrescriptionsSource.DataSource = currentTherapist.TherapistPrescriptions;
            InitializeComponent();
            

            grid_EmitedPrescriptions.DataSource = emittedPrescriptionsSource;

            // grid_ClientPrescriptions.Rows.Add("19/08/2010", "18:00", "Brufen");
        }

        private void grid_ClientPrescriptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_ClientPrescriptions.Columns[e.ColumnIndex].Name == "ChangePrescription")
            {
                var form = new ChangePrescriptionContentsForm();
                form.Show();
            }
        }
    }
}