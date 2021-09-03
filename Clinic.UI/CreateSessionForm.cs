using System;
using System.Windows.Forms;

namespace Clinic.UI
{
    public partial class CreateSessionForm : Form
    {
        public CreateSessionForm()
        {
            InitializeComponent();
        }

        private void btn_CreateSession_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sessão Marcada");
            this.Close();
        }
    }
}