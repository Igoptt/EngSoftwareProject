using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IClientRepository:IRepository<Client>
    {
        int Insert(Client client);
        List<Client> GetAll();
        int Update(Client client);
        List<Prescription> GetClientPrescriptions(int clientId);
        Client GetClientByName(string clientName);
        
        Client GetClientByUsername(string clientUsername);
        Client GetClientById(int clientId);
    }
}