using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public interface IUserRepository
    {
        bool Create(User user);
        void Update(User user);
        User GetById(int userId);
        List<User> GetAll();
        User GetUserByUsername(string username);
        bool Exists(string username);
        // User GetUserByUsernameAndPassword(string username, string password);
    }

}
