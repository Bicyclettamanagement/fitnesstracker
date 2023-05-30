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
        void Save(TrainingPlan trainingPlan);
        List<TrainingPlan> GetAll();
        TrainingPlan GetById(int id);
        void Update(TrainingPlan trainingPlan);
        void Delete(int trainingPlanId);
        
    }

}
