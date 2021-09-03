using System.Collections.Generic;
using System.Linq;

namespace Clinic.Data.Models
{
    //tudo o que são tabelas tem de existir aqui - isto é a nossa BD
    public class Database
    {
        public List<Client> Clients { get; set; }
        public List<Therapist> Therapists { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public List<Sessions> Sessions { get; set; }
        
        //todo fill all tables here and Lastinsertedids

        public int LastInsertedClientId = 0;
        public int LastInsertedTherapistId = 0;
    }
}