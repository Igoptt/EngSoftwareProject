using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Clinic.UI.FormHelpers;

namespace Clinic.UI
{
    public partial class CreateServiceForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly int _currentTherapistId;
        private readonly CreateServiceFormHelper _createServiceFormHelper;
        public CreateServiceForm(UnitOfWork unitOfWork, int currentTherapistId)
        {
            _unitOfWork = unitOfWork;
            _currentTherapistId = currentTherapistId;
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
        
        //TODO verificações em cada botão (utilizar combo boxes talvez?)

        private void btn_SaveExercise_Click(object sender, EventArgs e)
        {
            var fieldsFilled = _createServiceFormHelper.ServiceFieldsFilled(textBox_ExerciseName.Text,
                textBox_ExerciseIntensity.Text, textBox_ExerciseSchedule.Text);
            if (fieldsFilled)
            {
                var exerciseDto = _createServiceFormHelper.CreateExercise(textBox_ExerciseName.Text,textBox_ExerciseIntensity.Text,textBox_ExerciseSchedule.Text);
                if (exerciseDto == null)
                {
                    MessageBox.Show("Ocorreu um erro ao criar este serviço. Verifique que a intensidade é apenas um numero inteiro");
                }
                else
                {
                    var exerciseDb = exerciseDto.MapToExerciseDb();
                    var createdExerciseId = _unitOfWork.ExercisesRepository.Insert(exerciseDb);
                    exerciseDto.Id = createdExerciseId;
                    MessageBox.Show("Exercicio criado!");
                    Close(); 
                }
                
            }
            else 
            {
                MessageBox.Show("Por favor preencha os campos");
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
                var createdMedicineId = _unitOfWork.MedicinesRepository.Insert(medicineDb);
                medicineDto.Id = createdMedicineId;
                MessageBox.Show("Medicamento criado!");
                Close();
            }
            else 
            {
                MessageBox.Show("Por favor preencha os campos");
            }
        }

        private void btn_SaveTreatment_Click(object sender, EventArgs e)
        {
            var fieldsFilled = _createServiceFormHelper.ServiceFieldsFilled(textBox_TreatmentName.Text,
                textBox_TreatmentType.Text, textBox_TreatmentDuration.Text);
            if (fieldsFilled)
            {
                var treatmentDto = _createServiceFormHelper.CreateTreatment(textBox_TreatmentName.Text,textBox_TreatmentDuration.Text,textBox_TreatmentType.Text);
                var treatmentDb = treatmentDto.MapToTreatmentDb();
                var createdTreatmentId = _unitOfWork.TreatmentsRepository.Insert(treatmentDb);
                treatmentDto.Id = createdTreatmentId;
                MessageBox.Show("Tratamento criado!");
                Close();
            }
            else 
            {
                MessageBox.Show("Por favor preencha os campos");
            }
        }
    }
}