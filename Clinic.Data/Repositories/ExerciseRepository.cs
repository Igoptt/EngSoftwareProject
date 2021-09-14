using System.Collections.Generic;
using System.Linq;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class ExerciseRepository:RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(DatabaseContext context) : base(context)
        {
        }

        public int Insert(Exercise exercise)
        {
            
            exercise.Id = GetId(); 
            Database.Exercises.Add(exercise);
            Save();
            return Database.Exercises.First(e => e.Id == exercise.Id).Id;
        }


        public Exercise GetExerciseById(int exerciseId)
        {
            return Database.Exercises.FirstOrDefault(e => e.Id == exerciseId);
        }
        
        
        public List<Exercise> GetAll()
        {
            return Database.Exercises;
        }
        public int Update(Exercise exercise)
        {
            var dbExercise = Database.Exercises.FirstOrDefault(e => e.Id == exercise.Id);
            if (dbExercise != null)
            {
                var dbIndex = Database.Exercises.IndexOf(dbExercise);
                Database.Exercises[dbIndex] = exercise;
                Save();
                return dbExercise.Id;
            }

            return 0;
        }
    }
}