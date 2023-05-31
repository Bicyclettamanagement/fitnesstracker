using FitnessTracker.Domain;
using FitnessTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class LoginUseCase
    {
        private readonly IAppContainer _appContainer;
        private readonly AuthenticationService _authenticationService;

        public LoginUseCase(IAppContainer appContainer)
        {
            _appContainer = appContainer;
            _authenticationService = appContainer.CreateAuthenticationService();
        }

        public User Execute(string username, string password)   
        {
            if(_authenticationService.LoginSuccessful(username, password))
            {
                return _appContainer.CreateUserService().GetUserByName(username);
            } else
            {
                throw new Exception("Login not successful");
            }
        }
    }

}
