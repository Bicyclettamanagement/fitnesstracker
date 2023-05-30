using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public interface ITrainingPlanRepository
    {
        void SaveTrainingPlan(TrainingPlan trainingPlan);
        TrainingPlan GetTrainingPlanById(int id);
        void UpdateTrainingPlan(TrainingPlan trainingPlan);
        void DeleteTrainingPlan(TrainingPlan trainingPlan);
        
    }

}
