using FitnessTracker.Domain;
using FitnessTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class RegisterUseCase
    {
        private readonly IAppContainer _appContainer;
        private readonly UserService _userService;
        private readonly AuthenticationService _authenticationService;

        public RegisterUseCase(IAppContainer appContainer)
        {
            _appContainer = appContainer;
            _userService = appContainer.CreateUserService();
            _authenticationService = appContainer.CreateAuthenticationService();
        }

        public void Execute(string username, string password, string birthday, string weight)
        {
            
            if (_userService.UserExists(username))
            {
                throw new InvalidOperationException("Der Benutzername ist bereits vergeben.");
            }
            if (username == null) 
            {
                throw new ArgumentNullException("The username must not be empty");
            }
            if (password == null)
            {
                throw new ArgumentNullException("The password must not be empty");
            }
            


            User user = new User(username, password, convertStringToDateTime(birthday), convertStringToFloat(weight));

            _userService.CreateUser(user);

            _authenticationService.LoginSuccessful(username, password);
        }
        private DateTime convertStringToDateTime(string dateString)
        {
            string format = "dd.MM.yyyy";
            DateTime date;
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            } else { throw new Exception("Invalid birthday date. Please use the format dd.mm.yyyy"); }
        }
        private float convertStringToFloat(string value)
        {
            return float.Parse(value); //todo
        }
    }
}

