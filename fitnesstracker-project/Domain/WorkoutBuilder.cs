using FitnessTracker.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class WorkoutBuilder
    {
        private Workout _workout;

        public WorkoutBuilder(IWorkoutService workoutService)
        {
            _workout = new Workout(workoutService);
        }

        public WorkoutBuilder WithExercise(PerformedExercise exercise)
        {
            _workout.AddExercise(exercise);
            return this;
        }

        public WorkoutBuilder WithUser(User user)
        {
            _workout.UserId = user.Id;
            return this;
        }

        public Workout Build()
        {
            return _workout;
        }
    }

}
