using System.Collections.Generic;
using System.Linq;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class MedicineRepository:RepositoryBase<Medicine>, IMedicineRepository
    {
        public MedicineRepository(DatabaseContext context) : base(context)
        {
        }
        public int Insert(Medicine medicine)
        {
            
            medicine.Id = GetId(); 
            Database.Medicines.Add(medicine);
            Save();
            return Database.Medicines.First(m => m.Id == medicine.Id).Id;
        }

        public Medicine GetMedicineById(int medicineId)
        {
            return Database.Medicines.FirstOrDefault(m => m.Id == medicineId);
        }
        
        public List<Medicine> GetAll()
        {
            return Database.Medicines;
        }
        public int Update(Medicine medicine)
        {
            var medicineDb = Database.Medicines.FirstOrDefault(m => m.Id == medicine.Id);
            if (medicineDb != null)
            {
                var dbIndex = Database.Medicines.IndexOf(medicineDb);
                Database.Medicines[dbIndex] = medicine;
                Save();
                return medicineDb.Id;
            }

            return 0;
        }
        

    }
}