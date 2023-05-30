using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Domain;

namespace FitnessTracker.Plugin
{
    public class DbManager : IDbManager
    {
        public bool PasswordCorrect(string username, string password)
        {
            return true;
        }
        public User GetAthleteByUsername(string username)
        {
            User athlete = new User(username, DateTime.Now, 80.0f);
            return athlete;
        }
        public bool UsernameExists(string username)
        {
            return true;
        }
    }
}
