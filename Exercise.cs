using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Musclegroups;

namespace FitnessTracker
{
    internal class Exercise : IExercise
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IMuscle> Agonists;
        public List<IMuscle> Synergists;
        public bool IsUnilateral { get; set; }
        public float CurrentWeight { get; set; }
        public int CurrentReps { get; set; }
        public float OneRepMax { get; set; }
        public string Notes { get; set; }
        
        

        public Exercise(string name)
        {
            this.Name = name;
            this.Description = "";
            this.Agonists = new List<IMuscle>();
            this.Synergists = new List<IMuscle>(); 
            this.IsUnilateral = false;
            this.Notes = "";
        }
        public Exercise(string name, string description, List<IMuscle> agonists, List<IMuscle> synergists, bool isUnilateral)
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
