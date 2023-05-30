using FitnessTracker.Adapter;
using FitnessTracker.Application;

static class Program
{
    static void Main()
    {
        // Erzeugung der Repositories
        IExerciseRepository exerciseRepository = new ExerciseRepository();
        IUserRepository userRepository = new UserRepository();
        IWorkoutRepository workoutRepository = new WorkoutRepository();
        ITrainingPlanRepository trainingPlanRepository = new TrainingPlanRepository();

        // Erzeugung der Service-Klassen mit den entsprechenden Repositories
        ExerciseService exerciseService = new ExerciseService(exerciseRepository);
        UserService userService = new UserService(userRepository);
        WorkoutService workoutService = new WorkoutService(workoutRepository);
        TrainingPlanService trainingPlanService = new TrainingPlanService(trainingPlanRepository);
        AuthenticationService authenticationService = new AuthenticationService(userRepository);

        // Erzeugung der Benutzeroberfläche und Übergabe der Service-Klassen
        StartUserInterface consoleUI = new StartUserInterface(userService, workoutService, trainingPlanService, authenticationService);

        // Starten der Benutzeroberfläche
        consoleUI.Run();
    }
}
