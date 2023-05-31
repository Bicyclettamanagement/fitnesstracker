using FitnessTracker.Adapter;
using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class CreateWorkoutUseCase
    {
        public CreateWorkoutUseCase() 
        {
        }
        public Workout CreateManualWorkout(string workoutName)
        {
            
            return new Workout(workoutName);
        }
    }
}
