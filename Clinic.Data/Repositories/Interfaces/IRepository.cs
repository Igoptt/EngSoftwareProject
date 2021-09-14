using System.Collections.Generic;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Save();
    }
}