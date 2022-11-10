using FitnessTracker.Musclegroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    internal class Athlete
    {
        public string Name { get; set; }
        public DateOnly Birthday { get; }
        public float Weight { get; set; }
        public List<IMuscle>? TrainedMuscles;
        public List<ITrainingPlan>? TrainingPlans;
        public Athlete(string name, DateOnly birthday, float weight)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Weight = weight; 
        }
    }
}
