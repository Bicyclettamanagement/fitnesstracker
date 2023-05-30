using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class LoginUseCase
    {
        private readonly AuthenticationService _authenticationService;

        public LoginUseCase(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public bool Execute(string username, string password)
        {
            return _authenticationService.LoginSuccessful(username, password);
        }
    }

}
