using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class DbManager : IDbManager
    {
        public bool PasswordCorrect(string username, string password)
        {
            return true;
        }
        public Athlete GetAthleteByUsername(string username)
        {
            Athlete athlete = new Athlete(username, DateTime.Now, 80.0f);
            return athlete;
        }
        public bool UsernameExists(string username)
        {
            return true;
        }
    }
}
