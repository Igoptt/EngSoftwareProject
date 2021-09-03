using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IServiceRepository:IRepository<Service>
    {
        int Insert(Service service);
        Service GetServiceById(int serviceId);
        List<Service> GetAll();
        int Update(Service service);
    }
}