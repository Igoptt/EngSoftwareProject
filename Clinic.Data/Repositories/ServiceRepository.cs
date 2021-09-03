using System.Collections.Generic;
using System.Linq;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class ServiceRepository:RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(DatabaseContext context) : base(context)
        {
        }
        
        public int Insert(Service service)
        {
            
            service.Id = GetId(); 
            Database.Services.Add(service);
            Save();
            return Database.Services.First(m => m.Id == service.Id).Id;
        }

        private int GetId()
        {
            var lastId = Database.LastInsertedServiceId++;
            Database.LastInsertedServiceId = lastId;
            return lastId;
        }

        public Service GetServiceById(int serviceId)
        {
            return Database.Services.FirstOrDefault(m => m.Id == serviceId);
        }
        
        public List<Service> GetAll()
        {
            return Database.Services;
        }
        public int Update(Service service)
        {
            var serviceDb = Database.Services.FirstOrDefault(s => s.Id == service.Id);
            if (serviceDb != null)
            {
                var dbIndex = Database.Services.IndexOf(serviceDb);
                Database.Services[dbIndex] = service;
                return serviceDb.Id;
            }

            return 0;
        }
        
        
    }
}