using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public static class DataMapperDtoToDb
    {
        //MapToClientDb(clientDto)
        // public static Client MapToClientDb2(ClientDto dto)
        //or
        //clientDto.MapToClientDb()
        public static Client MapToClientDb(this ClientDto dto) 
        {
            var clientDb = new Client();
            clientDb.Id = dto.Id;
            clientDb.Password = dto.Password;
            clientDb.Username = dto.Username;
            clientDb.FirstName = dto.FirstName;
            clientDb.LastName = dto.LastName;
            
            for (int i = 0; i < dto.ClientAppointments.Count; i++)
            {
                SessionsDto sessions = dto.ClientAppointments[i];
                //clientDb.ClientAppointments.Add(MapToSessionsDb(sessions));
            }
            
            for (int i = 0; i < dto.ClientPrescriptions.Count; i++)
            {
                PrescriptionDto prescription = dto.ClientPrescriptions[i];
                //clientDb.ClientPrescriptions.Add(MapToPrescriptionDb(prescription));
            }
            
            return clientDb;
        }

        public static Exercise MapToExerciseDb(this ExerciseDto dto)
        {
            return new Exercise
            {
                
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                PrescriptionId = dto.PrescriptionId,
                
                Intensity = dto.Intensity,
                SuggestedSchedule = dto.SuggestedSchedule,
                
            };
        }

        public static Medicine MapToMedicineDb(this MedicineDto dto)
        {
            return new Medicine
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                PrescriptionId = dto.PrescriptionId,
                
                Dosage = dto.Dosage,
                TimeOfDayToTakeMedicine = dto.TimeOfDayToTakeMedicine,
            };
        }

        public static Prescription MapToPrescriptionDb(PrescriptionDto dto)
        {
            var prescriptionDb = new Prescription();
            prescriptionDb.Id = dto.Id;
            prescriptionDb.ClientId = dto.ClientId;
            prescriptionDb.PrescriptionAuthorId = dto.PrescriptionAuthorId;
            prescriptionDb.TherapistsWithAcess = dto.TherapistsWithAcess;
            for (int i = 0; i < dto.PrescribedServices.Count; i++)
            {
                ServiceDto service = dto.PrescribedServices[i];
                //prescriptionDb.PrescribedServices.Add(MapToServiceDb(service));
            }
            
            return prescriptionDb;
        }

        public static Service MapToServiceDb(this ServiceDto dto)
        {
            return new Service
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                PrescriptionId = dto.PrescriptionId,
                
            };
        }

        public static Sessions MapToSessionsDb(this SessionsDto dto)
        {
            return new Sessions
            {
                Id = dto.Id,
                AssignedTherapistId = dto.AssignedTherapistId,
                AssignedClientId = dto.AssignedClientId,
                SessionDate = dto.SessionDate,
                TheraphistSessionNote = dto.TheraphistSessionNote,
                SessionActivities = dto.SessionActivities,
            };
        }

        public static Therapist MapToTherapistDb(this TherapistDto dto)
        {
            var therapistDb = new Therapist();
            therapistDb.Id = dto.Id;
            therapistDb.Password = dto.Password;
            therapistDb.Username = dto.Username;
            therapistDb.FirstName = dto.FirstName;
            therapistDb.LastName = dto.LastName;
            
            for (int i = 0; i < dto.TherapistPrescriptions.Count; i++)
            {
                PrescriptionDto prescription = dto.TherapistPrescriptions[i];
                //therapistDb.TherapistPrescriptions.Add(MapToPrescriptionDb(prescription));
            }
            
            for (int i = 0; i < dto.TherapistSessions.Count; i++)
            {
                SessionsDto session = dto.TherapistSessions[i];
                //therapistDb.TherapistSessions.Add(MapToSessionsDb(session));
            }
            
            return therapistDb;
        }

        public static Treatment MapToTreatmentDb(this TreatmentDto dto)
        {
            return new Treatment
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                PrescriptionId = dto.PrescriptionId,
                
                Duration = dto.Duration,
                Type = dto.Type,
            };
        }
        
        
        
    }
}