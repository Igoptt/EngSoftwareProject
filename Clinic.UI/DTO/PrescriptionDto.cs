using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public class PrescriptionDto
    {
        
        public PrescriptionDto()
        {
            TherapistsWithAcess = new List<int>();
            PrescribedServices = new List<ServiceDto>();
        }
        
        public int Id { get; set; }
        public List<int> TherapistsWithAcess { get; set; }
        public List<ServiceDto> PrescribedServices { get; set; }
        
        //Foreign key for the Client this was prescribed to
        public int ClientId { get; set; }
        
        //foreign key for the Therapist who emmited this prescription
        public int PrescriptionAuthorId { get; set; }
        
    }
}