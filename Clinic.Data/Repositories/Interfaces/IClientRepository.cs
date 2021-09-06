using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IClientRepository:IRepository<Client>
    {
        // TEntity Get(int id);
        // IEnumerable<TEntity> GetAll();
        // //IEnumerable<TEntity> FindByCondition (E)
        // void Add(TEntity entity);
        // void Remove(TEntity entity);
        // void Update(TEntity entity);
        int Insert(Client client);
        List<Client> GetAll();
        int Update(Client client);
        List<Prescription> GetClientPrescriptions(int clientId);
        Client GetClientByName(string clientName);
        List<Medicine> GetPrescribedMedicines(int clientId);
        List<Exercise> GetPrescribedExercises(int clientId);
        List<Treatment> GetPrescribedTreatments(int clientId);
        Client GetClientByUsername(string clientUsername);
        Client GetClientById(int clientId);
    }
}