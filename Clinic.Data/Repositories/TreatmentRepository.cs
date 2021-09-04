using System.Collections.Generic;
using System.Linq;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class TreatmentRepository:RepositoryBase<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(DatabaseContext context) : base(context)
        {
        }
        
        public int Insert(Treatment treatment)
        {
            
            treatment.Id = GetId(); //todo need to increment
            Database.Treatments.Add(treatment);
            Save();
            return Database.Treatments.First(m => m.Id == treatment.Id).Id;
        }


        public Treatment GetTreatmentById(int treatmentId)
        {
            return Database.Treatments.FirstOrDefault(t => t.Id == treatmentId);
        }
        
        public List<Treatment> GetAll()
        {
            return Database.Treatments;
        }
        public int Update(Treatment treatment)
        {
            var treatmentDb = Database.Treatments.FirstOrDefault(t => t.Id == treatment.Id);
            if (treatmentDb != null)
            {
                var dbIndex = Database.Treatments.IndexOf(treatmentDb);
                Database.Treatments[dbIndex] = treatment;
                return treatmentDb.Id;
            }

            return 0;
        }
    }
}