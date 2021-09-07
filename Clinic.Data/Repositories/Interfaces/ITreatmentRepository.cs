using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface ITreatmentRepository:IRepository<Treatment>
    {
        int Insert(Treatment treatment);
        Treatment GetTreatmentById(int treatmentId);
        List<Treatment> GetAll();
        int Update(Treatment treatment);
    }
}