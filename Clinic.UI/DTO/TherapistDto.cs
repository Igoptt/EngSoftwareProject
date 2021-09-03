using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public class TherapistDto : UserDto
    {
        public TherapistDto()
        {
            TherapistPrescriptions = new List<PrescriptionDto>();
            TherapistSessions = new List<SessionsDto>();
        }
        
        public List<PrescriptionDto> TherapistPrescriptions { get; set; }
        public List<SessionsDto> TherapistSessions { get; set; }
    }
}