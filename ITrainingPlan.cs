﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public interface ITrainingPlan
    {
        public List<IExercise> Exercises { get; set; }
    }
}
