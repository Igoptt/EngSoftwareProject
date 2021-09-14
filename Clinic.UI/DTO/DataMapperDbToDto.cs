using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public static class DataMapperDbToDto
    {
        public static ClientDto MapToClientDto(this Client clientDb) 
        {
            var clientDto = new ClientDto();
            clientDto.Id = clientDb.Id;
            clientDto.Password = clientDb.Password;
            clientDto.Username = clientDb.Username;
            clientDto.FirstName = clientDb.FirstName;
            clientDto.LastName = clientDb.LastName;
            
            return clientDto;
        }
        
        public static ExerciseDto MapToExerciseDto(this Exercise exerciseDb)
        {
            return new ExerciseDto()
            {
                
                Id = exerciseDb.Id,
                Name = exerciseDb.Name,
                Intensity = exerciseDb.Intensity,
                SuggestedSchedule = exerciseDb.SuggestedSchedule,
                
            };
        }
        
        public static MedicineDto MapToMedicineDto(this Medicine medicineDb)
        {
            return new MedicineDto
            {
                Id = medicineDb.Id,
                Name = medicineDb.Name,
                Dosage = medicineDb.Dosage,
                TimeOfDayToTakeMedicine = medicineDb.TimeOfDayToTakeMedicine,
            };
        }
        
        public static PrescriptionDto MapToPrescriptionDto(this Prescription prescriptionDb)
        {
            var prescriptionDto = new PrescriptionDto();
            prescriptionDto.Id = prescriptionDb.Id;
            prescriptionDto.ClientId = prescriptionDb.ClientId;
            prescriptionDto.PrescriptionAuthorId = prescriptionDb.PrescriptionAuthorId;
            
            return prescriptionDto;
        }
        
        public static List<PrescriptionDto> MapPrescriptionsToDto(this List<Prescription> prescriptionsDb)
        {
            var prescriptionsDto = new List<PrescriptionDto>();
            
            foreach (var prescription in prescriptionsDb)
            {
                prescriptionsDto.Add(prescription.MapToPrescriptionDto());
            }
            return prescriptionsDto;
        }

        public static List<SessionsDto> MapSessionsToDto(this List<Sessions> sessionsDb)
        {
            var sessionsDto = new List<SessionsDto>();
            foreach (var session in sessionsDb)
            {
                sessionsDto.Add(session.MapToSessionToDto());
            }

            return sessionsDto;
        }

        public static SessionsDto MapToSessionToDto(this Sessions sessionsDb)
        {
            return new SessionsDto()
            {
                Id = sessionsDb.Id,
                AssignedTherapistId = sessionsDb.AssignedTherapistId,
                AssignedClientId = sessionsDb.AssignedClientId,
                SessionDate = sessionsDb.SessionDate,
                TheraphistSessionNote = sessionsDb.TheraphistSessionNote,
                SessionPrescriptionId = sessionsDb.SessionPrescriptionId,
            };
        }

        
        
        public static TherapistDto MapToTherapistDto(this Therapist therapistDb)
        {
            var therapistDto = new TherapistDto();
            therapistDto.Id = therapistDb.Id;
            therapistDto.Password = therapistDb.Password;
            therapistDto.Username = therapistDb.Username;
            therapistDto.FirstName = therapistDb.FirstName;
            therapistDto.LastName = therapistDb.LastName;
            return therapistDto;
        }
        
        public static TreatmentDto MapToTreatmentDto(this Treatment treatmentDb)
        {
            return new TreatmentDto()
            {
                Id = treatmentDb.Id,
                Name = treatmentDb.Name,
                Duration = treatmentDb.Duration,
                Type = treatmentDb.Type,
            };
        }
        
    }
}