using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public interface IAuthenticationService
    {
        bool LoginSuccessful(string username, string password);
        bool RegistrationSuccessful(User user);
        void Logout();
    }

}
