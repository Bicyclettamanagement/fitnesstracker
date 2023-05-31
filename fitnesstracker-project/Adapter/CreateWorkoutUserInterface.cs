using FitnessTracker.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class CreateWorkoutUserInterface
    {
        private readonly CreateWorkoutUseCase _createWorkoutUseCase;
        public CreateWorkoutUserInterface(CreateWorkoutUseCase createWorkoutUseCase)
        {
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
                        decisionMade= true;
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


        }
        public void ShowTrainingPlanWorkoutScreen()
        {

        }
    }
}
