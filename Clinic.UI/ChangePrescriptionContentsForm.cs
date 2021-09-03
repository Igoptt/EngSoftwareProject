using System;
using System.Windows.Forms;

namespace Clinic.UI
{
    public partial class ChangePrescriptionContentsForm : Form
    {
        public ChangePrescriptionContentsForm()
        {
            InitializeComponent();
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Mudanças Guardadas");
            this.Close();
        }
    }
}