using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Microsoft.VisualBasic;

namespace Clinic.UI
{
    public partial class TherapistViewForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private  TherapistDto _currentTherapist;
        private BindingSource therapistSessionsSource;
        public TherapistViewForm(DatabaseManager databaseManager, int therapistId)
        {
            
            _databaseManager = databaseManager;
            _currentTherapist = _databaseManager.TherapistViewingForm(therapistId);
            therapistSessionsSource = new BindingSource();
            therapistSessionsSource.DataSource = _currentTherapist.TherapistSessions;
            
            InitializeComponent();
            grid_SessionsTherapistView.DataSource = therapistSessionsSource;
            label_TherapistName.Text = $"{_currentTherapist.FirstName} {_currentTherapist.LastName}";
            
        }

        private void btn_AddPrescriptionToSession_Click(object sender, EventArgs e)
        {
            var form = new AddPrescriptionForm(_databaseManager, _currentTherapist);
            form.Show();
            Close();
        }
        
        private void grid_SessionsTherapistView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_SessionsTherapistView.Columns[e.ColumnIndex].Name == "RemoveAppointmentTherapistView")
            {
                //TODO este codigo esta repetido do clientViewForm, colocar num helper e chamar os metodos em ambos os forms para nao copiar e colar codigo
                var confirmation= MessageBox.Show("Confirmação", "Tem a certeza que deseja desmarcar esta consulta?", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    var selectedRowId = Convert.ToInt32(grid_SessionsTherapistView.CurrentRow.Cells["Id"].Value);
                    var sessionToDelete = _databaseManager.GetSpecificSession(selectedRowId);
                    
                    if (sessionToDelete.SessionDate <= DateTime.Now)
                    {
                        MessageBox.Show("Esta consulta já aconteceu");
                    }
                    else
                    {
                        var sessionClient = _databaseManager.GetSpecificClient(sessionToDelete.AssignedClientId);
                        var sessionTherapist = _currentTherapist.MapToTherapistDb();
                        sessionClient.ClientAppointments.Remove(sessionToDelete.Id);
                        _databaseManager.UpdateClient(sessionClient);
                        sessionTherapist.TherapistSessions.Remove(sessionToDelete.Id);
                        _databaseManager.UpdateTherapist(sessionTherapist);
                        var sessionDeleted = _databaseManager.DeleteSession(sessionToDelete);
                        
                        if (sessionDeleted == 1)
                        {
                            MessageBox.Show(@"Sessão Desmarcada!");
                            var selectedRow = grid_SessionsTherapistView.CurrentRow.Index;
                            grid_SessionsTherapistView.Rows.RemoveAt(selectedRow);
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro ao desmarcar esta sessão. Tente novamente");
                        }
                    }
                }
            }
            if (grid_SessionsTherapistView.Columns[e.ColumnIndex].Name == "AddSessionNoteTherapistView")
            {
                string message, title, defaultValue;
                object myValue;

                message = "Escreva a sua nota.";
                title = "Nota";
                
                defaultValue = "";

                myValue = Interaction.InputBox(message, title);

                //cancel
                if ((string)myValue == "")
                {
                    myValue = defaultValue;
                    Microsoft.VisualBasic.Interaction.MsgBox("Nota não adicionada.",
                        MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Nota");
                }
                //ok Add a note to session
                else
                {
                    var selectedRowId = Convert.ToInt32(grid_SessionsTherapistView.CurrentRow.Cells["Id"].Value);
                    var sessionToAddedNote = _databaseManager.GetSpecificSession(selectedRowId);
                    var sessionDto = sessionToAddedNote.MapToSessionToDto();
                    sessionDto.TheraphistSessionNote = myValue.ToString();
                    
                    Interaction.MsgBox(" ' " + myValue.ToString() + " ' "+ Environment.NewLine + "Nota Adicionada.",
                        MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Nota");
                    
                    var sessionDb = sessionDto.MapToSessionsDb();
                    var updatedSession = _databaseManager.UpdateSession(sessionDb);
                }
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ShowPrescriptions_Click(object sender, EventArgs e)
        {
            var form = new ClientPrescriptionsForm(_databaseManager,_currentTherapist);
            form.Show();
        }
    }
}