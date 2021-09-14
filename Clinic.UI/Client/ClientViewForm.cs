using System;
using System.Windows.Forms;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class ClientViewForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private readonly ClientDto _currentClient;

        public ClientViewForm(DatabaseManager databaseManager, int clientId)
        
        {
            _databaseManager = databaseManager;
            _currentClient = _databaseManager.ClientViewingForm(clientId);
            
            var clientSessionsSource = new BindingSource();
            clientSessionsSource.DataSource = _currentClient.ClientAppointments;

            var clientPrescriptionsSource = new BindingSource();
            clientPrescriptionsSource.DataSource = _currentClient.ClientPrescriptions;
            
            InitializeComponent();
            
            lb_ClientName.Text = $"{_currentClient.FirstName} {_currentClient.LastName}";
            
            //Liga a tabela á lista de sessoes do cliente
            grid_ClientSessions.DataSource = clientSessionsSource;
            //liga a tabela á lista de prescrições do cliente
            grid_PrescriptionsClientView.DataSource = clientPrescriptionsSource;
            
        }
        
        private void grid_PrescriptionsClientView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_PrescriptionsClientView.Columns[e.ColumnIndex].Name == "Mais") // mostra os detalhes sobre os varios serviços daqela prescrição
            {
                var selectedRowPrescriptionId = Convert.ToInt32(grid_PrescriptionsClientView.CurrentRow.Cells["Id"].Value);
                var prescriptionInformation = _databaseManager.GetPrescriptionServicesInformation(_currentClient.ClientPrescriptions, selectedRowPrescriptionId);
                if (!string.IsNullOrEmpty(prescriptionInformation))
                {
                    MessageBox.Show(prescriptionInformation);
                }
                else
                {
                    MessageBox.Show(@"Nao foi encontrada informação acerca desta prescrição");
                }
            }
            else if (grid_PrescriptionsClientView.Columns[e.ColumnIndex].Name == "Visibilidade")
            {
                var selectedPrescriptionId = Convert.ToInt32(grid_PrescriptionsClientView.CurrentRow.Cells["Id"].Value);
                var form = new ChangePrescriptionVisibilityForm(_databaseManager,_currentClient,selectedPrescriptionId);
                form.Show();
            }
        }

        private void btn_CreateSessionClientView_Click(object sender, EventArgs e)
        {
            var form = new CreateSessionForm(_databaseManager, _currentClient);
            form.Show();
            this.Close();
        }


        private void grid_ClientSessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "DetalhesClientView")
            {
                var sessionTherapist = Convert.ToInt32(grid_ClientSessions.CurrentRow.Cells["AssignedTherapistId"].Value);
                var therapistDto = _databaseManager.GetSpecificTherapistDb(sessionTherapist).MapToTherapistDto();
                MessageBox.Show($"A sessão tem uma duração de 1 hora com o terapeuta {therapistDto.FirstName} {therapistDto.LastName} ");
            }
            else if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "EditarSessao")
            {
                //atualiza a sessao com este Id
                var selectedSessionId = Convert.ToInt32(grid_ClientSessions.CurrentRow.Cells["Id"].Value);

                if (_databaseManager.GetSpecificSession(selectedSessionId).SessionDate >= DateTime.Now)
                {
                    var form = new EditSessionForm(_databaseManager, _currentClient, selectedSessionId);
                    form.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"Escolheu uma sessão que ja aconteceu!");
                }
            }
            else if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "DesmarcarClientView")
            {
                var confirmation= MessageBox.Show("Confirmção", "Tem a certeza que deseja desmarcar esta consulta?", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    var selectedRowId = Convert.ToInt32(grid_ClientSessions.CurrentRow.Cells["Id"].Value);
                    var sessionToDelete = _databaseManager.GetSpecificSession(selectedRowId);
                    var sessionToDeleteDto = sessionToDelete.MapToSessionToDto();
                    if (sessionToDelete.SessionDate <= DateTime.Now)
                    {
                        MessageBox.Show(@"Esta consulta ja aconteceu");
                    }
                    else
                    {
                        var sessionClient = _databaseManager.GetSpecificClient(_currentClient.Id);
                        var sessionTherapist = _databaseManager.GetSpecificTherapistDb(sessionToDelete.AssignedTherapistId);
                        sessionClient.ClientAppointments.Remove(sessionToDelete.Id);
                        _databaseManager.UpdateClient(sessionClient);
                        sessionTherapist.TherapistSessions.Remove(sessionToDelete.Id);
                        _databaseManager.UpdateTherapist(sessionTherapist);
                        
                        var sessionDeleted = _databaseManager.DeleteSession(sessionToDelete);
                        if (sessionDeleted == 1) //retorna 1 quando consegue apagar da Db
                        {
                            var selectedRow = grid_ClientSessions.CurrentRow.Index;
                            MessageBox.Show(@"Sessao Desmarcada!");
                            grid_ClientSessions.Rows.RemoveAt(selectedRow);
                        }
                        else
                        {
                            MessageBox.Show(@"Ocorreu um erro ao desmarcar esta sessão. Tente novamente");
                        }
                    }
                }
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}