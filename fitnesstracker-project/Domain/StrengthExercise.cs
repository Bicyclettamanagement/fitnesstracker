using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class StrengthExercise : Exercise
    {
        public StrengthExercise(string name) : base(name)
        {
        }
        public override string Description => "Strength Exercise";
    }
}
