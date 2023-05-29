using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public interface IExercise
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
