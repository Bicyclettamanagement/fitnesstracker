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
    public class LoginUserInterface
    {
        private readonly IAppContainer _appContainer;
        private readonly LoginUseCase _loginUseCase;

        public LoginUserInterface(IAppContainer appContainer, LoginUseCase loginUseCase)
        {
            _appContainer = appContainer;
            _loginUseCase = loginUseCase;
        }

        public void ShowLoginScreen()
        {
            Console.Clear();
            Console.WriteLine("FitnessTracker");
            Console.WriteLine("Login");
            Console.WriteLine();
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            try
            {
                User user = _loginUseCase.Execute(username, password);
                Console.WriteLine("Login successful!");
                _appContainer.SetUser(user);
                MainMenuUseCase mainMenuUseCase = new MainMenuUseCase(_appContainer);
                MainMenuUserInterface mainMenuUserInterface = new(_appContainer, mainMenuUseCase);
                mainMenuUserInterface.ShowMainMenuScreen();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }

}
