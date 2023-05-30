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
        void Create(User user);
        void Delete(int userId);
        void Update(User user);
        User GetById(int userId);
        List<User> GetAll();
        User GetUserByUsername(string username);
        bool Exists(string username);
        // User GetUserByUsernameAndPassword(string username, string password);
    }

}
