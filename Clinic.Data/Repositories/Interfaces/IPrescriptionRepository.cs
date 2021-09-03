using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IPrescriptionRepository:IRepository<Prescription>
    {
        int Insert(Prescription prescription);
        Prescription GetPrescriptionById(int prescriptionId);
        List<Prescription> GetAll();
        int Update(Prescription prescription);
        Therapist GetPrescriptonAuthor(Prescription prescription);
        Client GetPrescriptionClient(Prescription prescription);
    }
}