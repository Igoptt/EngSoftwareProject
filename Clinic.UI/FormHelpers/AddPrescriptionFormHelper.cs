using System;
using System.Collections.Generic;
using Clinic.UI.DTO;

namespace Clinic.UI.FormHelpers
{
    public class AddPrescriptionFormHelper
    {
        //TODO verificar se bastava colocar isto tudo na mesma função que simplesmente verifica se 3 caixas de texto estao preenchidas
        public bool MedicineFieldsFilled(string name, string dosage, string schedule)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(dosage) && string.IsNullOrEmpty(schedule))
            {
                return false;
            }

            return true;
        }

        public bool ExerciseFieldsFilled(string name, string intensity, string schedule)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(schedule) && string.IsNullOrEmpty(intensity))
            {
                return false;
            }
            
            return true;
        }

        public bool TreatmentFieldsFilled(string name, string type, string duration)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(type) && string.IsNullOrEmpty(duration))
            {
                return false;
            }
            
            return true;
        }
        
        
        //TODO criar 3 metodos um para criar cada tipo de serviço
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
            var durationNumber = Convert.ToInt32(duration);
            if (durationNumber != 0)
            {
                var treatment = new TreatmentDto()
                {
                    Name = treatmentName,
                    Id = 0,
                    Duration = durationNumber,
                    Type = type
                
                };
                return treatment;
            }

            return null;
        }

        //TODO criar 1 metodo para criar a prescrição tendo em conta que é preciso adicionar os ids dos serviços, terapeuta e cliente
        public PrescriptionDto CreatePrescription(int clientId, int theraphistAuthor, List<ServiceDto> prescriptionServices)
        {
            var prescription = new PrescriptionDto()
            {
                Id = 0,
                ClientId = clientId,
                PrescribedServices = prescriptionServices,
                PrescriptionAuthorId = theraphistAuthor,
            };
            return prescription;
            
        }
    }
}