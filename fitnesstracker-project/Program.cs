using FitnessTracker.Adapter;
using FitnessTracker.Application;
using FitnessTracker.Infrastructure;

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
        IAppContainer appContainer = new AppContainer(exerciseRepository, userRepository, workoutRepository, trainingPlanRepository);

        // Erzeugung der Benutzeroberfläche und Übergabe der Service-Klassen
        StartUserInterface consoleUI = new StartUserInterface(appContainer);

        // Starten der Benutzeroberfläche
        consoleUI.Run();
    }
}
