using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public abstract class ExerciseDecorator : PerformedExercise
    {
        protected PerformedExercise _exercise;

        public ExerciseDecorator(PerformedExercise exercise)
            : base(exercise.ExerciseId, 0, exercise.Weight)
        {
            _exercise = exercise;
        }
    }

    public class TimeExerciseDecorator : ExerciseDecorator
    {
        public int TimeInSeconds { get; set; }

        public TimeExerciseDecorator(PerformedExercise exercise, int timeInSeconds)
            : base(exercise)
        {
            TimeInSeconds = timeInSeconds;
        }
    }

}
