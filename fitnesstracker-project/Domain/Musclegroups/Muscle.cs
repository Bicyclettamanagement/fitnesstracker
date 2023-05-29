namespace FitnessTracker.Domain.Musclegroups
{
    public class Muscle : IMuscle
    {
        public string Name { get; set; }

        public Muscle(string name) { Name = name; }
    }
}