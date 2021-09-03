using System;
using System.Windows.Forms;

namespace Clinic.UI
{
    public partial class ChangePrescriptionVisibilityForm : Form
    {
        public ChangePrescriptionVisibilityForm()
        {
            InitializeComponent();
        }

        private void btn_SavePrescriptionVisibilityChanges_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"As suas alterações foram efetuadas");
            this.Close();
        }
    }
}