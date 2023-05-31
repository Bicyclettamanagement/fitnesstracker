using FitnessTracker.Adapter;
using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class MuscleService
    {
        private readonly IMuscleRepository muscleRepository;

        public MuscleService(IMuscleRepository muscleRepository)
        {
            this.muscleRepository = muscleRepository;
        }

        public Muscle CreateMuscle(string name, int volumePerWeek)
        {
            // Überprüfen, ob ein Muskel mit dem angegebenen Namen bereits existiert
            if (muscleRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException("Ein Muskel mit diesem Namen existiert bereits.");
            }

            // Erstellen und speichern Sie den neuen Muskel
            Muscle muscle = new Muscle(name, volumePerWeek);
            muscleRepository.Add(muscle);

            return muscle;
        }
        public Muscle GetMuscleById(int id)
        {
            return muscleRepository.GetById(id);
        }

        public IEnumerable<Muscle> GetAllMuscles()
        {
            // Holen Sie sich alle Muskeln aus dem Repository
            return muscleRepository.GetAll();
        }

        // Weitere Methoden des MuscleService...
    }

}
