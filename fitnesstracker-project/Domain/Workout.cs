using FitnessTracker.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class Workout
    {
        private readonly IWorkoutService _workoutService;
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'PerformedExercises' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<PerformedExercise> PerformedExercises { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'PerformedExercises' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        public Workout(WorkoutService workoutService)
        {
            _workoutService = workoutService;
            Date= DateTime.Now;
            PerformedExercises = new List<PerformedExercise>();
        }
    }
}
