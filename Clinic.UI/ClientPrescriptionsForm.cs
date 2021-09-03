using System.Windows.Forms;

namespace Clinic.UI
{
    public partial class ClientPrescriptionsForm : Form
    {
        public ClientPrescriptionsForm()
        {
            InitializeComponent();
            grid_ClientPrescriptions.Rows.Add("19/08/2010", "18:00", "Brufen");
        }

        private void grid_ClientPrescriptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_ClientPrescriptions.Columns[e.ColumnIndex].Name == "ChangePrescription")
            {
                var form = new ChangePrescriptionContentsForm();
                form.Show();
            }
        }
    }
}