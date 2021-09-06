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
                Price = exerciseDb.Price,
                PrescriptionId = exerciseDb.PrescriptionId,
                
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
                Price = medicineDb.Price,
                PrescriptionId = medicineDb.PrescriptionId,
                
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
            // prescriptionDb.TherapistsWithAcess = dto.TherapistsWithAcess;
            for (int i = 0; i < prescriptionDb.PrescribedServices.Count; i++)
            {
                int prescribedServiceId = prescriptionDb.PrescribedServices[i];
                // prescriptionDto.PrescribedServices.Add(prescribedServiceId);
                // ServiceDto service = dto.PrescribedServices[i];
                //prescriptionDb.PrescribedServices.Add(MapToServiceDb(service));
            }

            for (int i = 0; i < prescriptionDb.TherapistsWithAcess.Count; i++)
            {
                int therapistWithAcessId = prescriptionDb.TherapistsWithAcess[i];
                // prescriptionDto.TherapistsWithAcess.Add(therapistWithAcessId);
            }
            
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
                sessionsDto.Add(session.MapToSessionsDto());
            }

            return sessionsDto;
        }

        public static SessionsDto MapToSessionsDto(this Sessions sessionsDb)
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
            
            // for (int i = 0; i < therapistDb.TherapistPrescriptions.Count; i++)
            // {
            //     int therapistPrescriptionId = therapistDb.TherapistPrescriptions[i];
            //     // therapistDto.TherapistPrescriptions.Add(therapistPrescriptionId);
            //     // PrescriptionDto prescription = dto.TherapistPrescriptions[i];
            //     //therapistDb.TherapistPrescriptions.Add(MapToPrescriptionDb(prescription));
            // }
            //
            // for (int i = 0; i < therapistDb.TherapistSessions.Count; i++)
            // {
            //     int therapistSessionId = therapistDb.TherapistSessions[i];
            //     // therapistDto.TherapistSessions.Add(therapistSessionId);
            //     // SessionsDto session = dto.TherapistSessions[i];
            //     //therapistDb.TherapistSessions.Add(MapToSessionsDb(session));
            // }
            
            return therapistDto;
        }
        
        public static TreatmentDto MapToTreatmentDto(this Treatment treatmentDb)
        {
            return new TreatmentDto()
            {
                Id = treatmentDb.Id,
                Name = treatmentDb.Name,
                Price = treatmentDb.Price,
                PrescriptionId = treatmentDb.PrescriptionId,
                
                Duration = treatmentDb.Duration,
                Type = treatmentDb.Type,
            };
        }
        
    }
}