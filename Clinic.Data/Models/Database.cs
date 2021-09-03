using System.Collections.Generic;
using System.Linq;

namespace Clinic.Data.Models
{
    //tudo o que são tabelas tem de existir aqui - isto é a nossa BD
    public class Database
    {

        public Database()
        {
            Clients = new List<Client>();
            //estes 3 nao criam a lista pq???
            Therapists = new List<Therapist>();
            Prescriptions = new List<Prescription>();
            Treatments = new List<Treatment>();
            
            Exercises = new List<Exercise>();
            Medicines = new List<Medicine>();
            Services = new List<Service>();
            Users = new List<User>();
            Sessions = new List<Sessions>();
        }
        
        public List<Client> Clients { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<Medicine> Medicines { get; set; }
        public List<Service> Services { get; set; }
        
        //TODO descobrir o pq destes 3 começarem com a lista em NULL enquanto que os outros criam as listas
        public List<Therapist> Therapists { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Prescription> Prescriptions { get; set; }


        // public List<Therapist> Therapists { get; set; }
        // public List<Treatment> Treatments { get; set; }
        // public List<Prescription> Prescriptions { get; set; }
        
        public List<User> Users { get; set; }
        
        public List<Sessions> Sessions { get; set; }
        
        
        //nao iriam herdar o Id do User?
        public int LastInsertedClientId = 0;
        public int LastInsertedTherapistId = 0;
        
        //preciso destes 3? Eles usam o Id de Service como herdam os seus atributos nao?
        public int LastInsertedExerciseId = 0;
        public int LastInsertedMedicineId = 0;
        public int LastInsertedTreatmentId = 0;
        
        public int LastInsertedServiceId = 0;
        public int LastInsertedUserId = 0;
        public int LastInsertedPrescriptionId = 0;
        public int LastInsertedSessionId = 0;
    }
}