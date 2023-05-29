using FitnessTracker.Domain.Musclegroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class Athlete
    {
        public string Name { get; set; }
        public DateTime Birthday { get; }
        public float Weight { get; set; }
        public List<IMuscle>? TrainedMuscles;
        public List<ITrainingPlan>? TrainingPlans;

        public Athlete(string name, DateTime birthday, float weight)
        {
            Name = name;
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