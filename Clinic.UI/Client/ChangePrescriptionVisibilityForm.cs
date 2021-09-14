using System;
using System.Windows.Forms;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class ChangePrescriptionVisibilityForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private ClientDto _clientDto;
        private readonly int _prescriptionId;
        public ChangePrescriptionVisibilityForm(DatabaseManager databaseManager, ClientDto clientDto, int prescriptionId)
        {
            _databaseManager = databaseManager;
            _clientDto = clientDto;
            _prescriptionId = prescriptionId;
            
            var chosenPrescription = _databaseManager.GetChosenPrescriptionDb(_prescriptionId);
            InitializeComponent();
            
            var therapists = _databaseManager.GetAllTherapists();
            var prescriptionInformation = $"Escolheu a prescrição com o Id:{_prescriptionId} emitida por: ";
            foreach (var therapist in therapists)
            {
                if (therapist.Id != chosenPrescription.PrescriptionAuthorId)
                {
                    cb_ChooseTherapist.Items.Add($"Id do terapeuta:{therapist.Id}: Nome: {therapist.FirstName} {therapist.LastName}");
                }
                else
                {
                    prescriptionInformation += $"{therapist.FirstName} {therapist.LastName}";
                }
            }
            textBox_PrescriptionInformation.Text = prescriptionInformation;
        }

        private void btn_SavePrescriptionVisibilityChanges_Click(object sender, EventArgs e)
        {
            if (cb_ChooseTherapist.SelectedIndex > -1)
            {
                var selectedTherapistId = Convert.ToInt32(cb_ChooseTherapist.Text.Split(':')[1]);
                
                var prescriptionDb = _databaseManager.GetChosenPrescriptionDb(_prescriptionId);
                
                prescriptionDb.TherapistsWithAcess.Add(selectedTherapistId);
                
                var updatePrescription = _databaseManager.UpdatePrescription(prescriptionDb);
                
                if (updatePrescription != 0) //o update retorna 0 quando falha
                {
                    MessageBox.Show(@"As suas alterações foram efetuadas");
                    var form = new ClientViewForm(_databaseManager, _clientDto.Id);
                    form.Show();
                    Close();
                    
                }
                else
                {
                    MessageBox.Show(@"Ocorreu um erro! Tente novamente");
                }
            }
            else
            {
                MessageBox.Show(@"Por favor escolha um terapeuta para atribuir acesso");
            }
            
        }
    }
}