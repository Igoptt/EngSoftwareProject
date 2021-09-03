using System.Collections.Generic;
using System.Linq;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class TherapistRepository : RepositoryBase<Therapist>, ITherapistRepository
    {
        public TherapistRepository(DatabaseContext context) : base(context)
        {
        }
        public int Insert(Therapist therapist)
        {
            
            therapist.Id = GetId(); //todo need to increment
            Database.Therapists.Add(therapist);
            Save();
            return Database.Therapists.First(t => t.Id == therapist.Id).Id;
        }

        private int GetId()
        {
            var lastId = Database.LastInsertedTherapistId++;
            Database.LastInsertedTherapistId = lastId;
            return lastId;
        }

        public Therapist GetTherapistById(int therapistId)
        {
            return Database.Therapists.FirstOrDefault(t => t.Id == therapistId);
        }

        public Therapist GetTherapistByUsername(string therapistUsername)
        {
            return Database.Therapists.FirstOrDefault(t => t.Username == therapistUsername);
        }
        
        public List<Therapist> GetAll()
        {
            return Database.Therapists;
        }
        public int Update(Therapist therapist)
        {
            var therapistDb = Database.Therapists.FirstOrDefault(t => t.Id == therapist.Id);
            if (therapistDb != null)
            {
                var dbIndex = Database.Therapists.IndexOf(therapistDb);
                Database.Therapists[dbIndex] = therapist;
                return therapistDb.Id;
            }

            return 0;
        }
        
        
        //metodo para ir buscar todas as sessoes marcadas para o therapist com Id X        
    }
}