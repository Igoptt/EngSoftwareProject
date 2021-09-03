﻿using System.Collections.Generic;

namespace Clinic.Data.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public List<int> TherapistsWithAcess { get; set; }
        
        //Foreign key for the Client this was prescribed to
        public int ClientId { get; set; }
        
        //foreign key for the Therapist who emmited this prescription
        public int PrescriptionAuthorId { get; set; }
        
        public List<Service> PrescribedServices { get; set; }

        //um enum para o tipo de prescrição em vez de ter serviços e dps aqeles 3?
    }
}