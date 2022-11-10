using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    internal interface IExercise
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
