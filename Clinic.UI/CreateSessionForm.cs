using System;
using System.Windows.Forms;

namespace Clinic.UI
{
    public partial class CreateSessionForm : Form
    {
        public CreateSessionForm()
        {
            InitializeComponent();
            cb_sessionHours.Items.AddRange(new []{"9:00", "9:30", "10:00"});
        }

        private void btn_CreateSession_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Sessão Marcada");
            this.Close();
        }
    }
}