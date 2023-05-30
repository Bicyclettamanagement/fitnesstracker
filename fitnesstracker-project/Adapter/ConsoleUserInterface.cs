using FitnessTracker.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class ConsoleUserInterface
    {
        private readonly UserService _userService;
        private readonly AuthenticationService _authenticationService;
        private readonly WorkoutService _workoutService;
        private readonly TrainingPlanService _trainingPlanService;


        public ConsoleUserInterface(UserService userService, WorkoutService workoutService, TrainingPlanService trainingPlanService, AuthenticationService authenticationService)
        {
            _userService = userService;
            _workoutService = workoutService;
            _trainingPlanService = trainingPlanService;
            _authenticationService = authenticationService;
        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Fitnesstracker!");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("");
                Console.WriteLine("Esc: Exit");
                Console.WriteLine("Choose an option:");

                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        Login();
                        break;
                    case ConsoleKey.D2:
                        Register();
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }

        private void Login()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            
            bool isAuthenticated = _authenticationService.LoginSuccessful(username, password);

            if (isAuthenticated)
            {
                Console.WriteLine("Login successful!");
                // todo
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void Register()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            
            bool isRegistered = _authenticationService.Register(username, password);

            if (isRegistered)
            {
                Console.WriteLine("Registration successful!");
                // todo
            }
            else
            {
                Console.WriteLine("Username already exists. Please try again with a different username.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void CreateWorkout()
        {
            Console.WriteLine("Enter workout details:");
            // todo

            _workoutService.CreateWorkout(/* Übergebene Parameter */);

            Console.WriteLine("Workout created successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void CreateTrainingPlan()
        {
            Console.WriteLine("Enter training plan details:");
            // todo

            _trainingPlanService.CreateTrainingPlan(/* Übergebene Parameter */);

            Console.WriteLine("Training plan created successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

}
