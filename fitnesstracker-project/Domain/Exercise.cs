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
        public List<int> Agonists;
        public List<int> Synergists;
        public bool IsUnilateral { get; set; }
        public int? OneRepMax { get; set; }



        public Exercise(string name)
        {
            Name = name;
            Description = "";
            Agonists = new();
            Synergists = new();
            IsUnilateral = false;
        }
        public Exercise(string name, string description, bool isUnilateral, int oneRepMax)
        {
            Name = name;
            Description = description;
            Agonists = new();
            Synergists = new();
            IsUnilateral = isUnilateral;
            OneRepMax = oneRepMax;
        }
        public Exercise(string name, string description, List<int> agonists, List<int> synergists, bool isUnilateral)
        {
            Name = name;
            Description = description;
            Agonists = agonists;
            Synergists = synergists;
            IsUnilateral = isUnilateral;
        }
        public Exercise(string name, string description, List<int> agonists, List<int> synergists, bool isUnilateral,int oneRepMax)
        {
            Name = name;
            Description = description;
            Agonists = agonists;
            Synergists = synergists;
            IsUnilateral = isUnilateral;
            OneRepMax = oneRepMax;

        }
        public void AddAgonist(int agonist)
        {
            Agonists.Add(agonist);
        }
        public void AddSynergist(int synergist)
        {
            Synergists.Add(synergist);
        }

    }
}
