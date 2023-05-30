using FitnessTracker.Adapter;
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
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        public TrainingPlanService(ITrainingPlanRepository trainingPlanRepository) 
        {
            _trainingPlanRepository= trainingPlanRepository;
        }
        public void CreateTrainingPlan(string name, List<Exercise> exercises)
        {
            TrainingPlan trainingPlan = new TrainingPlan(name, exercises);
            // todo
        }
    }
    

}
