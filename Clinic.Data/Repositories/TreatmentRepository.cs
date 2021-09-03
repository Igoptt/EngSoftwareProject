using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class TreatmentRepository:RepositoryBase<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(DatabaseContext context) : base(context)
        {
        }
    }
}