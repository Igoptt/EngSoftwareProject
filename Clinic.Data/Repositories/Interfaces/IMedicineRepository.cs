using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IMedicineRepository:IRepository<Medicine>
    {
        int Insert(Medicine medicine);
        Medicine GetMedicineById(int medicineId);
        List<Medicine> GetAll();
        int Update(Medicine medicine);
    }
}