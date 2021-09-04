using System.Collections.Generic;
using System.Linq;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class SessionsRepository:RepositoryBase<Sessions>, ISessionsRepository
    {
        public SessionsRepository(DatabaseContext context) : base(context)
        {
        }
        public int Insert(Sessions session)
        {
            
            session.Id = GetId(); //todo need to increment
            Database.Sessions.Add(session);
            Save();
            return Database.Sessions.First(s => s.Id == session.Id).Id;
        }

        public Sessions GetSessionById(int sessionId)
        {
            return Database.Sessions.FirstOrDefault(s => s.Id == sessionId);
        }
        
        public List<Sessions> GetAll()
        {
            return Database.Sessions;
        }
        public int Update(Sessions session)
        {
            var sessionDb = Database.Sessions.FirstOrDefault(s => s.Id == session.Id);
            if (sessionDb != null)
            {
                var dbIndex = Database.Sessions.IndexOf(sessionDb);
                Database.Sessions[dbIndex] = session;
                return sessionDb.Id;
            }

            return 0;
        }

        public int DeleteSession(Sessions session)
        {
            var sessionDb = Database.Sessions.FirstOrDefault(s => s.Id == session.Id);
            if (sessionDb != null)
            {
                Database.Sessions.Remove(session);
                return 1;
            }

            return 0;
        }
        
        
        //metodo para apagar a sessao
        
        
        
        
        
        
    }
}