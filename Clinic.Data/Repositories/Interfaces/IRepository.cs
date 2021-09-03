using System.Collections.Generic;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // TEntity Get(int id);
        // IEnumerable<TEntity> GetAll();
        // //IEnumerable<TEntity> FindByCondition (E)
        // void Add(TEntity entity);
        // void Remove(TEntity entity);
        // void Update(TEntity entity);
        void Save();
    }
}