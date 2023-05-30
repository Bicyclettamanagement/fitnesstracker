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
        public List<int> Exercises { get; set; }

        public TrainingPlan(string name)
        {
            Name = name;
            Exercises = new();
        }
        public TrainingPlan(string name, List<int> exercises)
        {
            Name = name;
            Exercises = exercises;
        }
        public void AddExercise(int exercise)
        {
            Exercises.Add(exercise);
        }
    }

}
