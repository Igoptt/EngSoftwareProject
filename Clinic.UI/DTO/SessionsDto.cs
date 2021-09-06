using System;

namespace Clinic.UI.DTO
{
    public class SessionsDto
    {
        public int Id { get; set; }
        
        //foreign key for the Therapist that will be present
        public int AssignedTherapistId { get; set; }
        
        //foreign key for the client the session is for
        public int AssignedClientId { get; set; }
        
        public DateTime SessionDate { get; set; }
        
        public string TheraphistSessionNote { get; set; }
        
        public int SessionPrescriptionId { get; set; }
    }
}