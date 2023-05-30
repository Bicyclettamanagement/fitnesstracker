using FitnessTracker.Adapter;
using FitnessTracker.Domain;
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
        public bool LoginSuccessful(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            return user != null && user.Password == password;
        }
        public void RegistrationSuccessful(User user)
        {
            _userRepository.Create(user);
        }

        public void Logout()
        {
            //todo
        }
    }
}
