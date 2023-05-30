using FitnessTracker.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class LoginUserInterface
    {
        private readonly LoginUseCase _loginUseCase;

        public LoginUserInterface(LoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        public void ShowLoginScreen()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            bool isAuthenticated = _loginUseCase.Execute(username, password);

            if (isAuthenticated)
            {
                Console.WriteLine("Login successful!");
                // Continue
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }

}
