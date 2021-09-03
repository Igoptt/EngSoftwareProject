using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;

namespace Clinic.UI
{
    public partial class ClientViewForm : Form
    {
        public ClientViewForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            grid_ClientSessions.Rows.Add("data K", "Hora x", "Terapeuta Y");
            grid_PrescriptionsClientView.Rows.Add("Medicamento", "Terapeuta Y", "Data K");
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
            var form = new CreateSessionForm();
            form.Show();
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
                var form = new CreateSessionForm();
                form.Show();
            }
            else if (grid_ClientSessions.Columns[e.ColumnIndex].Name == "DesmarcarClientView")
            {
                MessageBox.Show(@"Sessao Desmarcada!");
            }
        }
    }
}