using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface ISessionsRepository:IRepository<Sessions>
    {
        int Insert(Sessions session);
        Sessions GetSessionById(int sessionId);
        List<Sessions> GetAll();
        int Update(Sessions session);
        int DeleteSession(Sessions session);
    }
}