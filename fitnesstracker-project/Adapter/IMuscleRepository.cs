using FitnessTracker.Domain;
using FitnessTracker.Domain.Musclegroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public interface IMuscleRepository
    {
        
        void Add(Muscle muscle);
        void Delete(int muscleId);
        Muscle GetById(int muscleId);
        List<Muscle> GetAll();
        void Update(Muscle muscle);
    }
}
