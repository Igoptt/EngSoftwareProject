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
        private BindingSource clientSessions_Source;
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

            clientSessions_Source = new BindingSource();
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
                //TODO o que colocar aqui?
                MessageBox.Show(@"A sessão teve uma duração de X minutos e foram realizadas as prescrições Y e Z");
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
                        var sessionDeleted = _unitOfWork.SessionsRepository.Delete(sessionToDelete);
                        if (sessionDeleted == 1)
                        {
                            //TODO encontrar uma maneira de dar refresh (refresh datasource nao funciona; apagar da lista do datasource tambem nao)
                            var selectedRow = grid_ClientSessions.CurrentRow.Index;
                            // _currentClient.ClientAppointments.Remove(sessionToDeleteDto);
                            // Refresh();
                            // Update();
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