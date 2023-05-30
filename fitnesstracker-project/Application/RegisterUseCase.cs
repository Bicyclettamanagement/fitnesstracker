using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class RegisterUseCase
    {
        private readonly UserService _userService;
        private readonly AuthenticationService _authenticationService;

        public RegisterUseCase(UserService userService, AuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        public void Execute(string username, string password, string birthday, string weight)
        {
            
            if (_userService.UserExists(username))
            {
                throw new InvalidOperationException("Der Benutzername ist bereits vergeben.");
            }


            User user = new User(username, password, convertStringToDateTime(birthday), convertStringToFloat(weight));

            _userService.CreateUser(user);

            _authenticationService.LoginSuccessful(username, password);
        }
        private DateTime convertStringToDateTime(string value)
        {
            DateTime date= DateTime.strptime(); //todo
            return date;
        }
        private float convertStringToFloat(string value)
        {
            return float.Parse(value); //todo
        }
    }
}

