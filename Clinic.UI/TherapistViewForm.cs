using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Microsoft.VisualBasic;

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
            var therapistPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsEmmitedCByTherapist(therapistId);
            _currentTherapist = therapistBd.MapToTherapistDto();
            _currentTherapist.TherapistPrescriptions = therapistPrescriptions.MapPrescriptionsToDto();
            _currentTherapist.TherapistSessions = therapistSessions.MapSessionsToDto();
            
            var therapistSessions_source = new BindingSource();
            therapistSessions_source.DataSource = _currentTherapist.TherapistSessions;
            
            
            InitializeComponent();
            grid_SessionsTherapistView.DataSource = therapistSessions_source;
            label_TherapistName.Text = $"{_currentTherapist.FirstName} {_currentTherapist.LastName}";
            

        }

        private void btn_AddPrescriptionToSession_Click(object sender, EventArgs e)
        {
            var form = new AddPrescriptionForm(_unitOfWork, _currentTherapist.Id);
            form.Show();
        }

        

        private void grid_ClientsTherapistView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_ClientsTherapistView.Columns[e.ColumnIndex].Name == "Prescrições")
            {
                //ir buscar as precrições daqele cliente para mostrar
                var form = new ClientPrescriptionsForm(_unitOfWork,_currentTherapist.Id);
                form.Show();
            }
        }

        private void grid_SessionsTherapistView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_SessionsTherapistView.Columns[e.ColumnIndex].Name == "RemoveAppointmentTherapistView")
            {
                //TODO este codigo esta repetido do clientViewForm, colocar num helper e chamar os metodos em ambos os forms para nao copiar e colar codigo
                var confirmation= MessageBox.Show("Confirmção", "Tem a certeza que deseja desmarcar esta consulta?", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    var selectedRowId = Convert.ToInt32(grid_SessionsTherapistView.CurrentRow.Cells["Id"].Value);
                    var sessionToDelete = _unitOfWork.SessionsRepository.GetSessionById(selectedRowId);
                    if (sessionToDelete.SessionDate <= DateTime.Now)
                    {
                        MessageBox.Show("Esta consulta já aconteceu");
                    }
                    else
                    {
                        var sessionDeleted = _unitOfWork.SessionsRepository.Delete(sessionToDelete);
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
                    var sessionToAddedNote = _unitOfWork.SessionsRepository.GetSessionById(selectedRowId);
                    var sessionDto = sessionToAddedNote.MapToSessionsDto();
                    sessionDto.TheraphistSessionNote = myValue.ToString();
                    
                    Interaction.MsgBox(" ' " + myValue.ToString() + " ' "+ Environment.NewLine + "Nota Adicionada.",
                        MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Nota");
                    
                    var sessionDb = sessionDto.MapToSessionsDb();
                    _unitOfWork.SessionsRepository.Update(sessionDb);

                }
            }
            if (grid_SessionsTherapistView.Columns[e.ColumnIndex].Name == "Prescription")
            {
                var form = new ClientPrescriptionsForm(_unitOfWork,_currentTherapist.Id);
                form.Show();
            }
        }
    }
}