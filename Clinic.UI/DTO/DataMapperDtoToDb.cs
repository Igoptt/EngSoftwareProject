using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public static class DataMapperDtoToDb
    {
        //TODO dar double check do MapperToDb se é preciso ter os Ids
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
                int clientSessionId = dto.ClientAppointments[i].Id;
                clientDb.ClientAppointments.Add(clientSessionId);
                // SessionsDto sessions = dto.ClientAppointments[i];
                //clientDb.ClientAppointments.Add(MapToSessionsDb(sessions));
            }
            
            for (int i = 0; i < dto.ClientPrescriptions.Count; i++)
            {
                int clientPrescriptionId = dto.ClientPrescriptions[i].Id;
                clientDb.ClientPrescriptions.Add(clientPrescriptionId);
                // PrescriptionDto prescription = dto.ClientPrescriptions[i];
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
                // Price = dto.Price,
                // PrescriptionId = dto.PrescriptionId,
                
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
                // Price = dto.Price,
                // PrescriptionId = dto.PrescriptionId,
                
                Dosage = dto.Dosage,
                TimeOfDayToTakeMedicine = dto.TimeOfDayToTakeMedicine,
            };
        }

        public static Prescription MapToPrescriptionDb(this PrescriptionDto dto)
        {
            var prescriptionDb = new Prescription();
            prescriptionDb.Id = dto.Id;
            prescriptionDb.ClientId = dto.ClientId;
            prescriptionDb.PrescriptionAuthorId = dto.PrescriptionAuthorId;
            // prescriptionDb.TherapistsWithAcess = dto.TherapistsWithAcess;
            for (int i = 0; i < dto.PrescribedServices.Count; i++)
            {
                int prescribedServiceId = dto.PrescribedServices[i].Id;
                prescriptionDb.PrescribedServices.Add(prescribedServiceId);
                // ServiceDto service = dto.PrescribedServices[i];
                //prescriptionDb.PrescribedServices.Add(MapToServiceDb(service));
            }

            for (int i = 0; i < dto.TherapistsWithAcess.Count; i++)
            {
                int therapistWithAcessId = dto.TherapistsWithAcess[i].Id;
                prescriptionDb.TherapistsWithAcess.Add(therapistWithAcessId);
            }
            
            return prescriptionDb;
        }

        // public static Service MapToServiceDb(this ServiceDto dto)
        // {
        //     return new Service
        //     {
        //         Id = dto.Id,
        //         Name = dto.Name,
        //         Price = dto.Price,
        //         PrescriptionId = dto.PrescriptionId,
        //         
        //     };
        // }

        public static Sessions MapToSessionsDb(this SessionsDto dto)
        {
            return new Sessions
            {
                Id = dto.Id,
                AssignedTherapistId = dto.AssignedTherapistId,
                AssignedClientId = dto.AssignedClientId,
                SessionDate = dto.SessionDate,
                TheraphistSessionNote = dto.TheraphistSessionNote,
                SessionPrescriptionId = dto.SessionPrescriptionId,
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
                int therapistPrescriptionId = dto.TherapistPrescriptions[i].Id;
                therapistDb.TherapistPrescriptions.Add(therapistPrescriptionId);
                // PrescriptionDto prescription = dto.TherapistPrescriptions[i];
                //therapistDb.TherapistPrescriptions.Add(MapToPrescriptionDb(prescription));
            }
            
            for (int i = 0; i < dto.TherapistSessions.Count; i++)
            {
                int therapistSessionId = dto.TherapistSessions[i].Id;
                therapistDb.TherapistSessions.Add(therapistSessionId);
                // SessionsDto session = dto.TherapistSessions[i];
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
                // Price = dto.Price,
                // PrescriptionId = dto.PrescriptionId,
                
                Duration = dto.Duration,
                Type = dto.Type,
            };
        }
    }
}