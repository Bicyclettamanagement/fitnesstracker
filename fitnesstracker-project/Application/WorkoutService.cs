using FitnessTracker.Adapter;
using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public void AddWorkout(Workout workout)
        {
            _workoutRepository.Add(workout);
        }

        public void UpdateWorkout(Workout workout)
        {
            _workoutRepository.Update(workout);
        }

        public void DeleteWorkout(int workoutId)
        {
            _workoutRepository.Delete(workoutId);
        }

        public Workout GetWorkoutById(int workoutId)
        {
            return _workoutRepository.GetById(workoutId);
        }

        public List<Workout> GetAllWorkouts()
        {
            return _workoutRepository.GetAll();
        }
    }

}
