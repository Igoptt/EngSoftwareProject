using System.Collections.Generic;

namespace Clinic.Data.Models
{
    public class Prescription
    {

        public Prescription()
        {
            TherapistsWithAcess = new List<int>();
            PrescribedServices = new List<Service>();
        }
        
        public int Id { get; set; }
        public List<int> TherapistsWithAcess { get; set; }
        public List<Service> PrescribedServices { get; set; }
        
        //Foreign key for the Client this was prescribed to
        public int ClientId { get; set; }
        
        //foreign key for the Therapist who emmited this prescription
        public int PrescriptionAuthorId { get; set; }
        
        

        //um enum para o tipo de prescrição em vez de ter serviços e dps aqeles 3?
    }
}