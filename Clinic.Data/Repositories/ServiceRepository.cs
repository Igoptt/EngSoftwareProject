using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class ServiceRepository:RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(DatabaseContext context) : base(context)
        {
        }
        
        //metodo para ir buscar a prescrição associada ao serviço
        
    }
}