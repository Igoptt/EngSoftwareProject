using System.Collections.Generic;

namespace Clinic.Data.Models
{
    public class Therapist : User
    {
        public Therapist()
        {
            TherapistPrescriptions = new List<Prescription>();
            TherapistSessions = new List<Sessions>();
        }
        
        public List<Prescription> TherapistPrescriptions { get; set; }
        public List<Sessions> TherapistSessions { get; set; }
    }
}