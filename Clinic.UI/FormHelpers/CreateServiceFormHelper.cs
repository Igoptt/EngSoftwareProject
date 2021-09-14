using System;
using Clinic.UI.DTO;

namespace Clinic.UI.FormHelpers
{
    public class CreateServiceFormHelper
    {
        //TODO encontrar um nome decente para o placeholder
        public bool ServiceFieldsFilled(string name, string placeHolder, string schedule)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(placeHolder) && string.IsNullOrEmpty(schedule))
            {
                return false;
            }

            return true;
        }
        
        public MedicineDto CreateMedicine(string medicineName, string dosage, string time)
        {
            var medicine = new MedicineDto()
            {
                Name = medicineName,
                Dosage = dosage,
                Id = 0,
                TimeOfDayToTakeMedicine = time
            };
            return medicine;
        }
    
        public ExerciseDto CreateExercise(string exerciseName, string intensity,string schedule)
        {
            var intensityNumber = Convert.ToInt32(intensity);
            if (intensityNumber != 0)
            {
                var exercise = new ExerciseDto()
                {
                    Name = exerciseName,
                    Id = 0,
                    Intensity = intensityNumber,
                    SuggestedSchedule = schedule

                };
                return exercise;
            }

            return null;
        }
        
        public TreatmentDto CreateTreatment(string treatmentName, string duration, string type)
        {
            var treatment = new TreatmentDto()
            {
                Name = treatmentName,
                Id = 0,
                Duration = duration,
                Type = type
            };
            return treatment;
        }
    }
}