using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;
namespace Clinic.Data.Repositories
{
    public abstract class RepositoryBase<TEntity>:IRepository<TEntity> where TEntity:class
    {
        public readonly DatabaseContext Context;
        public readonly Database Database;

        public RepositoryBase(DatabaseContext context)
        {
            Context = context;
            Database = context.GetDataBase();
        }
        
        
        public void Save()
        {
            Context.SaveDatabase();
        }

        protected int GetId()
        {
            int lastId = 0;
            if (typeof(TEntity) == typeof(Therapist))
            {
                lastId = Database.LastInsertedTherapistId + 1;
                Database.LastInsertedTherapistId = lastId;
            }
            else if (typeof(TEntity) == typeof(Client))
            {
                lastId = Database.LastInsertedClientId + 1;
                Database.LastInsertedClientId = lastId;
            }
            else if (typeof(TEntity) == typeof(Exercise))
            {
                lastId = Database.LastInsertedExerciseId + 1;
                Database.LastInsertedExerciseId = lastId;
            }
            else if (typeof(TEntity) == typeof(Medicine))
            {
                lastId = Database.LastInsertedMedicineId + 1;
                Database.LastInsertedMedicineId = lastId;
            }
            else if (typeof(TEntity) == typeof(Prescription))
            {
                lastId = Database.LastInsertedPrescriptionId + 1;
                Database.LastInsertedPrescriptionId = lastId;
            }
            else if (typeof(TEntity) == typeof(Treatment))
            {
                lastId = Database.LastInsertedTreatmentId + 1;
                Database.LastInsertedTreatmentId = lastId;
            }
            else if (typeof(TEntity) == typeof(Sessions))
            {
                lastId = Database.LastInsertedSessionId + 1;
                Database.LastInsertedSessionId = lastId;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The type {typeof(TEntity)} is unknown");
            }
            return lastId;
        }

        

    }
}