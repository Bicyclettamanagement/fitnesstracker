using FitnessTracker.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class StartUserInterface
    {
        private readonly UserService _userService;
        private readonly AuthenticationService _authenticationService;
        private readonly WorkoutService _workoutService;
        private readonly TrainingPlanService _trainingPlanService;


        public StartUserInterface(UserService userService, WorkoutService workoutService, TrainingPlanService trainingPlanService, AuthenticationService authenticationService)
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
                        var loginUseCase = new LoginUseCase(_authenticationService);
                        var loginUserInterface = new LoginUserInterface(loginUseCase);
                        loginUserInterface.ShowLoginScreen();
                        break;
                    case ConsoleKey.D2:
                        var registerUseCase = new RegisterUseCase(_userService, _authenticationService);
                        var registerUserInterface = new RegisterUserInterface(registerUseCase);
                        registerUserInterface.ShowRegisterScreen();

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
