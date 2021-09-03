using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class SessionsRepository:RepositoryBase<Sessions>, ISessionsRepository
    {
        public SessionsRepository(DatabaseContext context) : base(context)
        {
        }
        
        //metodo para alterar a data
        
        //metodo para apagar a sessao
        
        //metodo para ir ver a nota da sessao
        
        //metodo para adicionar nota a sessao
        
        
    }
}