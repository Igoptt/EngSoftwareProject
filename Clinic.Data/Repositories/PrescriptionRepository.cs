using System.Collections.Generic;
using System.Linq;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class PrescriptionRepository:RepositoryBase<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(DatabaseContext context) : base(context)
        {
        }
        
        public int Insert(Prescription prescription)
        {
            
            prescription.Id = GetId(); //todo need to increment
            Database.Prescriptions.Add(prescription);
            Save();
            return Database.Prescriptions.First(p => p.Id == prescription.Id).Id;
        }

        private int GetId()
        {
            var lastId = Database.LastInsertedPrescriptionId++;
            Database.LastInsertedPrescriptionId = lastId;
            return lastId;
        }

        public Prescription GetPrescriptionById(int prescriptionId)
        {
            return Database.Prescriptions.FirstOrDefault(p => p.Id == prescriptionId);
        }
        
        public List<Prescription> GetAll()
        {
            return Database.Prescriptions;
        }
        public int Update(Prescription prescription)
        {
            var prescriptionDb = Database.Prescriptions.FirstOrDefault(p => p.Id == prescription.Id);
            if (prescriptionDb != null)
            {
                var dbIndex = Database.Prescriptions.IndexOf(prescriptionDb);
                Database.Prescriptions[dbIndex] = prescription;
                return prescriptionDb.Id;
            }

            return 0;
        }

        public Therapist GetPrescriptonAuthor(Prescription prescription)
        {
            return Database.Therapists.FirstOrDefault(t => t.Id == prescription.PrescriptionAuthorId);
        }
        
        // public List<Therapist> GetTherapistsWithAcess(int prescriptionId)
        // {
        //     
        // }
        
        //metodo para mudar a visibilidade da prescriçao, adicionar therapists a lista TherapistsWithAcess

        public Client GetPrescriptionClient(Prescription prescription)
        {
            return Database.Clients.FirstOrDefault(c => c.Id == prescription.ClientId);
        }
        
        //metodo para ir buscar os serviços da prescriçao 
        
    }
}