using FitnessTracker.Application;
using FitnessTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class MainMenuUserInterface
    {
        private readonly IAppContainer _appContainer;
        private readonly MainMenuUseCase _mainMenuUseCase;
        public MainMenuUserInterface(IAppContainer appContainer, MainMenuUseCase mainMenuUseCase)
        {
            _appContainer = appContainer;
            _mainMenuUseCase = mainMenuUseCase;
        }
        public void ShowMainMenuScreen()
        {
            bool loggedIn = true;
            while (loggedIn)
            {
                Console.Clear();
                Console.WriteLine("FitnessTracker");
                Console.WriteLine("Main Menu");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Start a Workout");
                Console.WriteLine("2: View  recent Workouts");
                Console.WriteLine("3: One-Rep-Max");
                Console.WriteLine("4: Create a new Exercise");
                Console.WriteLine("5: Create a Training Plan");
                Console.WriteLine("Esc: Logout");
                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:

                        break;
                    case ConsoleKey.D2:

                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        break;
                    case ConsoleKey.Escape:
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}
