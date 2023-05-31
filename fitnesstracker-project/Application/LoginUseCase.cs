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

        public bool Execute(string username, string password)
        {
            return _authenticationService.LoginSuccessful(username, password);
        }
    }

}
