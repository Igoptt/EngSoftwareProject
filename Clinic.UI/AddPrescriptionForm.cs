using System;
using System.Windows.Forms;

namespace Clinic.UI
{
    public partial class AddPrescriptionForm : Form
    {
        public AddPrescriptionForm()
        {
            InitializeComponent();
            
            
        }

        private void cb_ChooseSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ChooseSession.SelectedIndex >= 0)
            {
                grpBox_PrescriptionOptions.Visible = true;
            }
        }

        private void btn_SavePrescription_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Prescrição adicionada");
            this.Close();
        }
    }
}