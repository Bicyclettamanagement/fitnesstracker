using FitnessTracker.Application;
using FitnessTracker.Domain;

namespace FitnessTracker.Infrastructure
{
    public interface IAppContainer
    {
        User GetUser();
        void SetUser(User user);
        AuthenticationService CreateAuthenticationService();
        ExerciseService CreateExerciseService();
        TrainingPlanService CreateTrainingPlanService();
        UserService CreateUserService();
        WorkoutService CreateWorkoutService();
        MuscleService CreateMuscleService();
    }
}