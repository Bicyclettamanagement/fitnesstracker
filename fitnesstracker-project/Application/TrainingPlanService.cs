using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class TrainingPlanService
    {
        public void CreateTrainingPlan(string name, List<Exercise> exercises)
        {
            TrainingPlan trainingPlan = new TrainingPlan(name, exercises);
            // todo
        }
    }

}
