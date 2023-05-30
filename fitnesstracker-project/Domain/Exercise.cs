using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Domain.Musclegroups;

namespace FitnessTracker.Domain
{
    public class Exercise : IExercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Muscle> Agonists;
        public List<Muscle> Synergists;
        public bool IsUnilateral { get; set; }
        public float CurrentWeight { get; set; }
        public int CurrentReps { get; set; }
        public float OneRepMax { get; set; }
        public string Notes { get; set; }



        public Exercise(string name)
        {
            Name = name;
            Description = "";
            Agonists = new List<Muscle>();
            Synergists = new List<Muscle>();
            IsUnilateral = false;
            Notes = "";
        }
        public Exercise(string name, string description, List<Muscle> agonists, List<Muscle> synergists, bool isUnilateral)
        {
            Name = name;
            Description = description;
            Agonists = agonists;
            Synergists = synergists;
            IsUnilateral = isUnilateral;
            Notes = "";
        }

    }
}
