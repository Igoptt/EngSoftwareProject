using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface ITherapistRepository:IRepository<Therapist>
    {
        int Insert(Therapist therapist);
        Therapist GetTherapistById(int therapistId);
        List<Therapist> GetAll();
        int Update(Therapist therapist);
        Therapist GetTherapistByUsername(string therapistUsername);
        Therapist GetTherapistByFullName(string firstName, string lastName);
    }
}