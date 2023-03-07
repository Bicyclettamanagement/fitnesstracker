using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public interface IDbManager
    {
        Athlete GetAthleteByUsername(string username);
        bool PasswordCorrect(string username, string password);
        bool UsernameExists(string username);
    }
}
