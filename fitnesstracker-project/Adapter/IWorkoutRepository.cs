using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public interface IWorkoutRepository
    {
        void Add(Workout workout);
        void Update(Workout workout);
        void Delete(int workoutId);
        Workout GetById(int workoutId);
        List<Workout> GetAll();
    }

}
