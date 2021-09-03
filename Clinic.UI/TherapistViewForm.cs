using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;

namespace Clinic.UI
{
    public partial class TherapistViewForm : Form
    {
        public TherapistViewForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            grid_SessionsTherapistView.Rows.Add("Dia X", "Client Y");
            grid_ClientsTherapistView.Rows.Add("Nome Y", "Sobrenome Z","Dia X");

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