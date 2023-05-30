using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Exercise> Exercises { get; set; }

        public TrainingPlan(string name, List<Exercise> exercises)
        {
            Name = name;
            Exercises = exercises;
        }
    }

}
