using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    internal class Exercise
    {
        public string Name;
        public string Description;
        public List<Musclegroup> Agonists;
        public List<Musclegroup> Synergists;
        public bool IsUnilateral;
        public float CurrentWeight { get; set; }
        public int CurrentReps { get; set; }
        public float OneRepMax { get; set; }
        public string Notes { get; set; }

        public Exercise(string name)
        {
            this.Name = name;
            this.Description = "";
            this.Agonists = new List<Musclegroup>();
            this.Synergists = new List<Musclegroup>(); 
            this.IsUnilateral = false;
            this.Notes = "";
        }
        public Exercise(string name, string description, List<Musclegroup> agonists, List<Musclegroup> synergists, bool isUnilateral)
        {
            this.Name=name;
            this.Description=description;
            this.Agonists=agonists;
            this.Synergists=synergists;
            this.IsUnilateral=isUnilateral;
            this.Notes = "";
        }

    }
}
