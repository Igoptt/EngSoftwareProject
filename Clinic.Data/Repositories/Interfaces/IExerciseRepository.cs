using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IExerciseRepository:IRepository<Exercise>
    {
        int Insert(Exercise exercise);
        List<Exercise> GetAll();
        int Update(Exercise exercise);
    }
}