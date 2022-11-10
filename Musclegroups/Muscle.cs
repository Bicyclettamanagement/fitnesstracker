namespace FitnessTracker.Musclegroups
{
    public class Muscle : IMuscle
    {
        public string Name { get; set; }

        public Muscle(string name) { this.Name = name; }
    }
}