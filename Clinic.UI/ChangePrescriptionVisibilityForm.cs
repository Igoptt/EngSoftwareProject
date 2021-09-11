using System;
using System.Windows.Forms;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    public partial class ChangePrescriptionVisibilityForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int _currentClientId;
        private readonly int _prescriptionId;
        // private readonly SessionsDto selectedSession;
        public ChangePrescriptionVisibilityForm(UnitOfWork unitOfWork, int currentClientId, int prescriptionId)
        {
            _unitOfWork = unitOfWork;
            _currentClientId = currentClientId;
            _prescriptionId = prescriptionId;

            var chosenPrescription = _unitOfWork.PrescriptionsRepository.GetPrescriptionById(_prescriptionId);
            
            // selectedSession = _unitOfWork.SessionsRepository.GetSessionById(sessionId).MapToSessionsDto();
            InitializeComponent();

            // var clientSessions = _unitOfWork.SessionsRepository.GetClientSessions(_currentClientId).MapSessionsToDto();

            // foreach (var session in clientSessions)
            // {
            //     if (session.SessionPrescriptionId != -1)
            //     {
            //         cb_Sessions.Items.Add($"Id da sessão:{session.Id}: Com a prescrição:{session.SessionPrescriptionId}: Prescrita pelo terapeuta com o Id:{session.AssignedTherapistId}");
            //     }
            // }
            // textBox_PrescriptionInformation.Text = $"Escolheu a prescrição da sessão do dia: {selectedSession.SessionDate}";
            
            
            
            var therapists = _unitOfWork.TherapistRepository.GetAll();
            var prescriptionInformation = $"Escolehu a prescrição com o Id:{_prescriptionId} emitida por: ";
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
                
                // var prescriptionId = _prescriptionId;
                var prescriptionDb = _unitOfWork.PrescriptionsRepository.GetPrescriptionById(_prescriptionId);
                prescriptionDb.TherapistsWithAcess.Add(selectedTherapistId);
                var updatePrescription = _unitOfWork.PrescriptionsRepository.Update(prescriptionDb);
                if (updatePrescription != 0)
                {
                    MessageBox.Show(@"As suas alterações foram efetuadas");
                    var form = new ClientViewForm(_unitOfWork, _currentClientId);
                    form.Show();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro! Tente novamente");
                }
            }
            else
            {
                MessageBox.Show("Por favor escolha um terapeuta para atribuir acesso");
            }
            
            
            
        }
    }
}