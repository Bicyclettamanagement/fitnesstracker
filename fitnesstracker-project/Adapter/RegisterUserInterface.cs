using FitnessTracker.Application;
using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class RegisterUserInterface
    {
        private readonly RegisterUseCase _registerUseCase;
        public RegisterUserInterface(RegisterUseCase registerUseCase)
        {
            _registerUseCase = registerUseCase;
        }
        public void ShowRegisterScreen()
        {
            Console.Clear();
            Console.WriteLine("Fitnesstracker");
            Console.WriteLine();
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter your Birthday using the format dd.mm.yyyy");
            string birthday = Console.ReadLine();
            Console.WriteLine("Enter your current weight in kg");
            string weight = Console.ReadLine();

            
            try
            {
                _registerUseCase.Execute(username, password, birthday, weight);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                ShowRegisterScreen();
            }

            Console.WriteLine("Registration successful!");
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
