using FitnessTracker.Domain;

namespace FitnessTracker.Application
{
    public interface IWorkoutService
    {
        void AddWorkout(Workout workout);
        void DeleteWorkout(int workoutId);
        List<Workout> GetAllWorkouts();
        Workout GetWorkoutById(int workoutId);
        void UpdateWorkout(Workout workout);
    }
}