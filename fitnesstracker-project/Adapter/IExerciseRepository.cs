using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public interface IExerciseRepository
    {
        void Add(Exercise exercise);
        void Delete(int exerciseId);
        Exercise GetById(int exerciseId);
        List<Exercise> GetAll();
        void Update(Exercise exercise);
        List<Exercise> GetExercisesByMuscle(int muscleId);
    }

}
