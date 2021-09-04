using System.Collections.Generic;

namespace Clinic.Data.Models
{
    public class Therapist : User
    {
        public Therapist()
        {
            TherapistPrescriptions = new List<int>();
            TherapistSessions = new List<int>();
        }
        
        public List<int> TherapistPrescriptions { get; set; }
        public List<int> TherapistSessions { get; set; }
    }
}