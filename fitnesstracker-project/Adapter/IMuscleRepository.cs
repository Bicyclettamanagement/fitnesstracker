using FitnessTracker.Domain;
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
        Muscle GetByName(string name);
        List<Muscle> GetAll();
        void Update(Muscle muscle);
    }
}
