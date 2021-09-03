using System.Collections.Generic;

namespace Clinic.Data.Models
{
    public class Therapist : User
    {
        public List<Prescription> Prescriptions { get; set; }
        public List<Sessions> TherapistSessions { get; set; }
    }
}