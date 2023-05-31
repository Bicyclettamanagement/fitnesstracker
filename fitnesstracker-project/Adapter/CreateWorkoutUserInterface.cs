using FitnessTracker.Application;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class CreateWorkoutUserInterface
    {
        private readonly IAppContainer _appContainer;
        private readonly CreateWorkoutUseCase _createWorkoutUseCase;
        public CreateWorkoutUserInterface(IAppContainer appContainer, CreateWorkoutUseCase createWorkoutUseCase)
        {
            _appContainer = appContainer;
            _createWorkoutUseCase = createWorkoutUseCase;
        }
        public void ShowTrainingPlanDecisionScreen()
        {
            bool decisionMade = false;
            while (!decisionMade)
            {
                Console.Clear();
                Console.WriteLine("FitnessTracker");
                Console.WriteLine("Start a Workout");
                Console.WriteLine();
                Console.WriteLine("Would you like to follow a Training Plan?");
                Console.WriteLine("1: No, I want to add Exercises manually.");
                Console.WriteLine("2: Yes, I want to follow one of my Training Plans.");
                Console.WriteLine("Esc: Cancel Workout");
                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        decisionMade = true;
                        ShowManualWorkoutScreen();
                        break;
                    case ConsoleKey.D2:
                        decisionMade = true;
                        ShowTrainingPlanWorkoutScreen();
                        break;
                    case ConsoleKey.Escape:
                        decisionMade = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
        public void ShowManualWorkoutScreen()
        {
            Console.Clear();
            Console.WriteLine("FitnessTracker");
            Console.WriteLine("Manual Workout");
            Console.WriteLine();
            Console.WriteLine("Enter a name for your Workout:");
            string inputName;
            do { inputName = Console.ReadLine(); } while (inputName == null);
            Workout workout = _createWorkoutUseCase.CreateManualWorkout(inputName);
            bool workoutInProgress = true;
            while (workoutInProgress)
            {
                Console.Clear();
                Console.WriteLine("FitnessTracker");
                Console.WriteLine($"Manual Workout: {workout.Name}");
                Console.WriteLine();
                Console.WriteLine("1: Add an Exercise to the Workout");
                Console.WriteLine("2: Remove an Exercise from the Workout");
                Console.WriteLine("3: Save as Training Plan");
                Console.WriteLine("Esc: End Workout");
                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:

                        ShowAddExerciseToWorkoutScreen(workout);
                        break;
                    case ConsoleKey.D2:

                        ShowRemoveExerciseFromWorkoutScreen(workout);
                        break;
                    case ConsoleKey.D3:
                        _createWorkoutUseCase.SaveAsTrainingPlan(workout);
                        break;

                    case ConsoleKey.Escape:
                        workoutInProgress = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
            _createWorkoutUseCase.Save(workout);




        }

        public void ShowTrainingPlanWorkoutScreen()
        {
            Console.Clear();
            Console.WriteLine("FitnessTracker");
            Console.WriteLine("Training Plan Workout");
            Console.WriteLine();
            Console.WriteLine("Enter a name for your Workout:");
            string inputName;
            do { inputName = Console.ReadLine(); } while (inputName == null);
            Workout workout = _createWorkoutUseCase.CreateManualWorkout(inputName);
            TrainingPlan trainingPlan = ShowSelectTrainingPlanScreen();
            bool workoutInProgress = true;
            while (workoutInProgress)
            {
                foreach (int exerciseId in trainingPlan.Exercises)
                {
                    Exercise exercise = _createWorkoutUseCase.GetExerciseById(exerciseId);
                    Console.Clear();
                    Console.WriteLine("FitnessTracker");
                    Console.WriteLine($"Training Plan Workout: {workout.Name} - {trainingPlan.Name}");
                    Console.WriteLine();
                    Console.WriteLine($"Exercise: {exercise.Name}");
                    Console.WriteLine("How much weight did you use?");
                    string? weightString = null;
                    while (weightString == null) { weightString = Console.ReadLine(); }
                    Console.WriteLine("How many repetitions did you do?");
                    string? repsString = null;
                    while (repsString == null) { repsString = Console.ReadLine(); }
                    try
                    {
                        int weight = int.Parse(weightString);
                        int reps = int.Parse(repsString);
                        PerformedExercise performedExercise = new PerformedExercise(exercise.ExerciseId, reps, weight);
                        workout.AddExercise(performedExercise);
                    }
                    catch (Exception ex) { Console.WriteLine("Invalid input: " + ex.ToString()); }


                }
                workoutInProgress = false;

            }
            _createWorkoutUseCase.Save(workout);

        }

        private TrainingPlan ShowSelectTrainingPlanScreen()
        {
            TrainingPlan? selection = null;
            int selectionId = -1;
            while (selectionId < 0)
            {
                Console.Clear();
                Console.WriteLine("FitnessTracker");
                Console.WriteLine($"Training Plan Workout");
                Console.WriteLine();
                Console.WriteLine("Select a Trainingplan for this Workout:");

                List<TrainingPlan> availableTrainingPlans = _createWorkoutUseCase.GetAllTrainingPlans();
                int counter = 1;
                foreach (TrainingPlan plan in availableTrainingPlans)
                {
                    Console.WriteLine($"{counter}: {plan.Name}");
                }
                string? input = null;
                while (input == null) { input = Console.ReadLine(); }
                try
                {
                    selectionId = int.Parse(input) - 1;
                    selection = availableTrainingPlans[selectionId];

                }
                catch (Exception ex)
                {
                    selectionId = -1;
                    Console.WriteLine("Invalid input, press any key to continue...");
                    Console.ReadKey();
                }
            }
            if (selection == null)
            {
                selection = new TrainingPlan("Empty");
            }
            return selection;
        }

        private void ShowAddExerciseToWorkoutScreen(Workout workout)
        {
            List<Exercise> availableExercises = _createWorkoutUseCase.GetAvailableExercises();
            Exercise? selection = null;
            while (selection == null)
            {
                Console.Clear();
                Console.WriteLine("FitnessTracker");
                Console.WriteLine($"Manual Workout: {workout.Name}");
                Console.WriteLine();
                Console.WriteLine("Select an Exercise to add below:");
                int counter = 1;
                foreach (Exercise exercise in availableExercises)
                {
                    string workedMuscles = "";
                    foreach (int muscleId in exercise.Agonists)
                    {
                        Muscle agonist = _createWorkoutUseCase.GetMuscleById(muscleId);
                        workedMuscles += agonist.Name + " ";
                    }
                    Console.WriteLine($"{counter++}: {exercise.Name}");
                }
                string? input = null;
                while (input == null) { input = Console.ReadLine(); }
                try
                {
                    int selectionId = int.Parse(input) - 1;
                    selection = availableExercises[selectionId];
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input, press any key to continue...");
                    Console.ReadKey();
                }

            }
            Console.Clear();
            Console.WriteLine("FitnessTracker");
            Console.WriteLine($"Manual Workout: {workout.Name} - {selection.Name}");
            Console.WriteLine();
            Console.WriteLine("How much weight (in kg) did you use? (0 for bodyweight exercises)");
            string weightString = null;
            while (weightString == null) { weightString = Console.ReadLine(); }
            Console.WriteLine("How many repetitions did you do?");
            string repsString = null;
            while (repsString == null) { repsString = Console.ReadLine(); }

            try
            {
                int weight = int.Parse(weightString);
                int reps = int.Parse(repsString);
                PerformedExercise performedExercise = new PerformedExercise(selection.ExerciseId, reps, weight);
                workout.AddExercise(performedExercise);
            }
            catch (Exception ex) { Console.WriteLine("Invalid input: " + ex.ToString()); }
        }
        private void ShowRemoveExerciseFromWorkoutScreen(Workout workout)
        {
            Console.Clear();
            Console.WriteLine("FitnessTracker");
            Console.WriteLine($"Manual Workout: {workout.Name}");
            Console.WriteLine();
            Console.WriteLine("Select an Exercise to add below:");
            int counter = 1;
            foreach (PerformedExercise exercise in workout.PerformedExercises)
            {
                string exerciseName = _createWorkoutUseCase.GetExerciseById(exercise.ExerciseId).Name;
                Console.WriteLine($"{counter++}: {exerciseName}");
            }
            string? input = null;
            while (input == null) { input = Console.ReadLine(); }
            try
            {
                int selectionId = int.Parse(input) - 1;
                workout.PerformedExercises.Remove(workout.PerformedExercises[selectionId]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input, press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
