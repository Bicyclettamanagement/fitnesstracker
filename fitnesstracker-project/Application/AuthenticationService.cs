using FitnessTracker.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Login(string username, string password)
        {
            if(_userRepository.GetUserByUsernameAndPassword(username, password)!= null)
            {
                return true;
            } else { return false; }
        }

        public void Logout()
        {
            //todo
        }
    }
}
