using System;
using System.Windows.Forms;

namespace Clinic.UI
{
    public partial class CreateServiceForm : Form
    {
        public CreateServiceForm()
        {
            InitializeComponent();
            grpBox_Exercise.Visible = false;
            grpBox_Medicine.Visible = false;
            grpBox_Treatment.Visible = false;
        }
        
        private void cb_ServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ServiceType.SelectedIndex == 0) //medicamento
            {
                grpBox_Exercise.Visible = false;
                grpBox_Medicine.Visible = true;
                grpBox_Treatment.Visible = false;
            }

            if (cb_ServiceType.SelectedIndex == 1) //exercise
            {
                grpBox_Exercise.Visible = true;
                grpBox_Medicine.Visible = false;
                grpBox_Treatment.Visible = false;
            }

            if (cb_ServiceType.SelectedIndex == 2) //treatment
            {
                grpBox_Exercise.Visible = false;
                grpBox_Medicine.Visible = false;
                grpBox_Treatment.Visible = true;
            }
        }

        private void btn_SaveExercise_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btn_SaveMedicine_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void btn_SaveTreatment_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}