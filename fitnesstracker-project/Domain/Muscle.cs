namespace FitnessTracker.Domain
{
    public class Muscle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RecommendedVolumePerWeek;

        public Muscle(string name, int volumePerWeek) { Name = name; RecommendedVolumePerWeek = volumePerWeek; }
    }
}