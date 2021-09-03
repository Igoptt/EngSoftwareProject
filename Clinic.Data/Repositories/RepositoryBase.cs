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
        
        
    }
}