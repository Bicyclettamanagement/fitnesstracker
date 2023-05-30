﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain
{
    public class Workout
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<PerformedExercise> PerformedExercises { get; set; }
    }
}
