using FitnessTracker.Adapter;
using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool UserExists(string username)
        {
            return _userRepository.Exists(username);
        }

        public void CreateUser(User user)
        {
            _userRepository.Create(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
    
}
