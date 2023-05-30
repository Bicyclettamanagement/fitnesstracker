using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class PerformedExercise
    {
        public int ExerciseId { get; set; }
        public int Repetitions { get; set; }
        public double Weight { get; set; }
    }
}
