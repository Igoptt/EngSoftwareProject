using System;
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

            var clientSessions_Source = new BindingSource();
            clientSessions_Source.DataSource = _currentClient.ClientAppointments;
            
            
            InitializeComponent();
            lb_ClientName.Text = $"{_currentClient.FirstName} {_currentClient.LastName}";
            grid_ClientSessions.DataSource = clientSessions_Source;
            
            // grid_ClientSessions.Rows.Add("data K", "Hora x", "Terapeuta Y");
            // grid_PrescriptionsClientView.Rows.Add("Medicamento", "Terapeuta Y", "Data K");
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_PrescriptionsClientView.Columns[e.ColumnIndex].Name == "Mais")
            {
                MessageBox.Show(@"A prescrição tem uma intensidade de X ao longo de Y dias");
            }
            else if (grid_PrescriptionsClientView.Columns[e.ColumnIndex].Name == "Visibilidade")
            {
                var form = new ChangePrescriptionVisibilityForm();
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
                MessageBox.Show(@"A sessão teve uma duração de X minutos e foram realizadas as prescrições Y e Z");
            }
            else if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "EditarSessao")
            {
                //apaga a que tinha e cria uma nova
                var form = new CreateSessionForm(_unitOfWork, _currentClient.Id);
                form.Show();
            }
            else if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "DesmarcarClientView")
            {
                MessageBox.Show(@"Sessao Desmarcada!");
            }
        }
    }
}