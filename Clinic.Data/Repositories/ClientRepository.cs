using System;
using System.Collections.Generic;
using System.Linq;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(DatabaseContext context) : base(context)
        {
        }

        public int Insert(Client client)
        {
            
            client.Id = GetId(); 
            Database.Clients.Add(client);
            Save();
            return Database.Clients.First(c => c.Id == client.Id).Id;
        }


        public List<Client> GetAll()
        {
            return Database.Clients;
        }
        public int Update(Client client)
        {
            var dbClient = Database.Clients.FirstOrDefault(c => c.Id == client.Id);
            if (dbClient != null)
            {
                var dbIndex = Database.Clients.IndexOf(dbClient);
                Database.Clients[dbIndex] = client;
                Save();
                return dbClient.Id;
            }

            return 0;
        }

        public Client GetClientById(int clientId)
        {
            return Database.Clients.FirstOrDefault(c => c.Id == clientId);
        }
        
        public List<Prescription> GetClientPrescriptions(int clientId)
        {
            return Database.Prescriptions.Where(p => p.ClientId == clientId).ToList();
        }
        
        
        public Client GetClientByName(string clientName)
        {
            return Database.Clients.FirstOrDefault(c => c.FirstName == clientName);
        }

        public Client GetClientByUsername(string clientUsername)
        {
            return Database.Clients.FirstOrDefault(c => c.Username == clientUsername);
        }
        
       
        
        
        


    }
}