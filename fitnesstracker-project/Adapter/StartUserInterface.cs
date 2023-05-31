using FitnessTracker.Application;
using FitnessTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class StartUserInterface
    {
        private readonly IAppContainer _appContainer;
        private readonly UserService _userService;
        private readonly AuthenticationService _authenticationService;


        public StartUserInterface(IAppContainer appContainer)
        {
            _appContainer= appContainer;
            _userService = appContainer.CreateUserService();
            _authenticationService= appContainer.CreateAuthenticationService();
        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Fitnesstracker!");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Register");
                Console.WriteLine("");
                Console.WriteLine("Esc: Exit");
                Console.WriteLine("Press a key to choose an option");

                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        var loginUseCase = new LoginUseCase(_appContainer);
                        var loginUserInterface = new LoginUserInterface(_appContainer, loginUseCase);
                        loginUserInterface.ShowLoginScreen();
                        break;
                    case ConsoleKey.D2:
                        var registerUseCase = new RegisterUseCase(_appContainer);
                        var registerUserInterface = new RegisterUserInterface(_appContainer, registerUseCase);
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


        
    }

}
