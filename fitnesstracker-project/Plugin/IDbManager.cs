using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Domain;

namespace FitnessTracker.Plugin
{
    public interface IDbManager
    {
        Athlete GetAthleteByUsername(string username);
        bool PasswordCorrect(string username, string password);
        bool UsernameExists(string username);
    }
}
