using FitnessTracker.Application;

namespace FitnessTracker.Infrastructure
{
    public interface IAppContainer
    {
        AuthenticationService CreateAuthenticationService();
        ExerciseService CreateExerciseService();
        TrainingPlanService CreateTrainingPlanService();
        UserService CreateUserService();
        WorkoutService CreateWorkoutService();
    }
}