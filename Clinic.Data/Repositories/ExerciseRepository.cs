using System.Collections.Generic;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class ExerciseRepository:RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(DatabaseContext context) : base(context)
        {
        }

        // public List<Exercise> GetRecommendedHours(int clientId, int exerciseId)
        // {
        //     
        // }

    }
}