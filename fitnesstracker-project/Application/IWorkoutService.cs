using FitnessTracker.Domain;

namespace FitnessTracker.Application
{
    public interface IWorkoutService
    {
        void SaveWorkout(Workout workout);
        void DeleteWorkout(int workoutId);
        List<Workout> GetAllWorkouts();
        Workout GetWorkoutById(int workoutId);
        void UpdateWorkout(Workout workout);
    }
}