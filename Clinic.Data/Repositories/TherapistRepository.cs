using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class TherapistRepository : RepositoryBase<Therapist>, ITherapistRepository
    {
        public TherapistRepository(DatabaseContext context) : base(context)
        {
        }
        
        //metodo para ir buscar todas as sessoes marcadas para o therapist com Id X        
    }
}