using FitnessTracker.Musclegroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
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
            this.Name = name;
            this.Birthday = new DateTime(birthday.Year, birthday.Month, birthday.Day);
            this.Weight = weight;
        }

        public int GetAge()
        {
            var today = DateTime.Today;

            var a = today.Year * 10000 + today.Month * 100 + today.Day;
            var b = this.Birthday.Year * 10000 + this.Birthday.Month * 100 + this.Birthday.Day;

            return (a - b) / 10000;
        }
    }
}