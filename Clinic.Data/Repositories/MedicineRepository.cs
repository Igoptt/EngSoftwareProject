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
            
            medicine.Id = GetId(); //todo need to increment
            Database.Medicines.Add(medicine);
            Save();
            return Database.Medicines.First(m => m.Id == medicine.Id).Id;
        }

        private int GetId()
        {
            var lastId = Database.LastInsertedMedicineId++;
            Database.LastInsertedMedicineId = lastId;
            return lastId;
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
                return medicineDb.Id;
            }

            return 0;
        }
        

    }
}