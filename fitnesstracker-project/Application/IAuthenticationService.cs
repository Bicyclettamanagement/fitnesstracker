using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public interface IAuthenticationService
    {
        bool Login(string username, string password);
        void Logout();
    }

}
