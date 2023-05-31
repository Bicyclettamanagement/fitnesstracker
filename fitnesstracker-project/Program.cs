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
        IMuscleRepository muscleRepository= new MuscleRepository();

        // Erzeugung der Service-Klassen mit den entsprechenden Repositories
        IAppContainer appContainer = new AppContainer(exerciseRepository, userRepository, workoutRepository, trainingPlanRepository, muscleRepository);

        // Erzeugung der Benutzeroberfläche und Übergabe der Service-Klassen
        StartUserInterface consoleUI = new StartUserInterface(appContainer);

        // Starten der Benutzeroberfläche
        consoleUI.Run();
    }
}
