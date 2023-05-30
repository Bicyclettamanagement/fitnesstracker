using FitnessTracker.Adapter;
using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public void AddExercise(Exercise exercise)
        {
            _exerciseRepository.Add(exercise);
        }

        public void DeleteExercise(int exerciseId)
        {
            _exerciseRepository.Delete(exerciseId);
        }

        public void UpdateExercise(Exercise exercise)
        {
            _exerciseRepository.Update(exercise);
        }

        public Exercise GetExerciseById(int exerciseId)
        {
            return _exerciseRepository.GetById(exerciseId);
        }

        public List<Exercise> GetAllExercises()
        {
            return _exerciseRepository.GetAll();
        }

        public List<Exercise> GetExercisesByMuscle(int muscleId)
        {
            return _exerciseRepository.GetExercisesByMuscle(muscleId);
        }

    }
}
