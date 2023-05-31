using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; }
        public float Weight { get; set; }
        public List<Muscle>? TrainedMuscles;
        public List<ITrainingPlan>? TrainingPlans;

        public User(string name, string password, DateTime birthday, float weight)
        {
            Username = name;
            Password = password;
            Birthday = new DateTime(birthday.Year, birthday.Month, birthday.Day);
            Weight = weight;
        }

        public int GetAge()
        {
            var today = DateTime.Today;

            var a = today.Year * 10000 + today.Month * 100 + today.Day;
            var b = Birthday.Year * 10000 + Birthday.Month * 100 + Birthday.Day;

            return (a - b) / 10000;
        }
    }
}