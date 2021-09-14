using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class ClientPrescriptionsForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private TherapistDto _currentTherapist;
        private List<Prescription> acessiblePrescriptions;
        private TherapistDto dummyTherapist;
        public ClientPrescriptionsForm(DatabaseManager databaseManager, TherapistDto currentTherapist)
        {
            _databaseManager = databaseManager;
            _currentTherapist = currentTherapist;
            acessiblePrescriptions = new List<Prescription>();
            
            var prescriptionsDb = _databaseManager.GetAllPrescriptions();
            
            //este therapist apenas tem a lista das prescrições as quais tem acesso isto serve para nao ser necessario criar funções novas e poder reutilizar as existentes no Database Manager
            dummyTherapist = new TherapistDto();
            
            
            foreach (var prescription in prescriptionsDb)
            {
                if (prescription.TherapistsWithAcess.Contains(_currentTherapist.Id))
                {
                    acessiblePrescriptions.Add(prescription);
                }
            }

            dummyTherapist.TherapistPrescriptions = acessiblePrescriptions.MapPrescriptionsToDto();
            dummyTherapist.TherapistPrescriptions = _databaseManager.TherapistPrescriptionsWithServicesDto(acessiblePrescriptions,dummyTherapist);

            var emittedPrescriptionsSource = new BindingSource();
            emittedPrescriptionsSource.DataSource = _currentTherapist.TherapistPrescriptions;

            var acessiblePrescriptionsSource = new BindingSource();
            acessiblePrescriptionsSource.DataSource = dummyTherapist.TherapistPrescriptions;
            InitializeComponent();
            
            grid_EmitedPrescriptions.DataSource = emittedPrescriptionsSource;
            grid_PrescriptionsWithClientGrantedAcess.DataSource = dummyTherapist.TherapistPrescriptions;

        }

        private void grid_EmitedPrescriptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_EmitedPrescriptions.Columns[e.ColumnIndex].Name == "Mais")
            {
                var selectedRowPrescriptionId = Convert.ToInt32(grid_EmitedPrescriptions.CurrentRow.Cells["Id"].Value);
                var prescriptionInformation = _databaseManager.GetPrescriptionServicesInformation(_currentTherapist.TherapistPrescriptions,selectedRowPrescriptionId);
                
                if (!string.IsNullOrEmpty(prescriptionInformation))
                {
                    MessageBox.Show(prescriptionInformation);
                }
                else
                {
                    MessageBox.Show(@"Não foi encontrada informação acerca desta prescrição");
                }
            }
        }

        private void grid_PrescriptionsWithClientGrantedAcess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_PrescriptionsWithClientGrantedAcess.Columns[e.ColumnIndex].Name == "More")
            {
                var selectedRowPrescriptionId = Convert.ToInt32(grid_PrescriptionsWithClientGrantedAcess.CurrentRow.Cells["Id"].Value);
                var prescriptionInformation = _databaseManager.GetPrescriptionServicesInformation(dummyTherapist.TherapistPrescriptions,selectedRowPrescriptionId);
                
                if (!string.IsNullOrEmpty(prescriptionInformation))
                {
                    MessageBox.Show(prescriptionInformation);
                }
                else
                {
                    MessageBox.Show(@"Não foi encontrada informação acerca desta prescrição");
                }
            }
        }
    }
}