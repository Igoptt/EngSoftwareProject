using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Clinic.UI.FormHelpers;

namespace Clinic.UI
{
    public partial class CreateServiceForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private readonly CreateServiceFormHelper _createServiceFormHelper;
        private TherapistDto _currentTherapist;
        public CreateServiceForm(DatabaseManager databaseManager, TherapistDto currentTherapist)
        {
            _databaseManager = databaseManager;
            _currentTherapist = currentTherapist;
            _createServiceFormHelper = new CreateServiceFormHelper();
            
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
            var fieldsFilled = _createServiceFormHelper.ServiceFieldsFilled(textBox_ExerciseName.Text, cb_ExerciseIntensity.Text, textBox_ExerciseSchedule.Text);
            if (fieldsFilled)
            {
                var exerciseDto = _createServiceFormHelper.CreateExercise(textBox_ExerciseName.Text,cb_ExerciseIntensity.Text,textBox_ExerciseSchedule.Text);
                if (exerciseDto == null)
                {
                    MessageBox.Show(@"Ocorreu um erro ao criar este serviço. Verifique que a intensidade é apenas um número inteiro");
                }
                else
                {
                    var exerciseDb = exerciseDto.MapToExerciseDb();
                    var createdExerciseId = _databaseManager.InsertNewExercise(exerciseDb);
                    exerciseDto.Id = createdExerciseId;
                    MessageBox.Show("Exercício criado!");
                    var form = new AddPrescriptionForm(_databaseManager,_currentTherapist);
                    form.Show();
                    Close(); 
                }
            }
            else 
            {
                MessageBox.Show("Por favor preencha os campos!");
            }
        }

        private void btn_SaveMedicine_Click(object sender, EventArgs e)
        {
            var fieldsFilled = _createServiceFormHelper.ServiceFieldsFilled(textBox_MedicineName.Text,
                textBox_MedicineDosage.Text, textBox_MedicineSchedule.Text);
            if (fieldsFilled)
            {
                var medicineDto = _createServiceFormHelper.CreateMedicine(textBox_MedicineName.Text,textBox_MedicineDosage.Text,textBox_MedicineSchedule.Text);
                var medicineDb = medicineDto.MapToMedicineDb();
                var createdMedicineId = _databaseManager.InsertNewMedicine(medicineDb);
                medicineDto.Id = createdMedicineId;
                MessageBox.Show("Medicamento criado!");
                var form = new AddPrescriptionForm(_databaseManager,_currentTherapist);
                form.Show();
                Close();
            }
            else 
            {
                MessageBox.Show("Por favor preencha os campos!");
            }
        }

        private void btn_SaveTreatment_Click(object sender, EventArgs e)
        {
            var fieldsFilled = _createServiceFormHelper.ServiceFieldsFilled(textBox_TreatmentName.Text,
                textBox_TreatmentType.Text, cb_TreatmentDuration.Text);
            if (fieldsFilled)
            {
                var treatmentDto = _createServiceFormHelper.CreateTreatment(textBox_TreatmentName.Text,cb_TreatmentDuration.Text,textBox_TreatmentType.Text);
                var treatmentDb = treatmentDto.MapToTreatmentDb();
                var createdTreatmentId = _databaseManager.InsertNewTreatment(treatmentDb);
                treatmentDto.Id = createdTreatmentId;
                MessageBox.Show("Tratamento criado!");
                var form = new AddPrescriptionForm(_databaseManager,_currentTherapist);
                form.Show();
                Close();
            }
            else 
            {
                MessageBox.Show("Por favor preencha os campos!");
            }
        }
    }
}