namespace FitnessTracker.Domain.Musclegroups
{
    public class Muscle
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Muscle(string name) { Name = name; }
    }
}