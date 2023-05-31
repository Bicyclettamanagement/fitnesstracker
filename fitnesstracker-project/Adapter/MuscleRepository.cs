using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class MuscleRepository : IMuscleRepository
    {
        private const string FolderPath = @"./data/";
        private string FilePath;
        public MuscleRepository()
        {
            this.FilePath = Path.Combine(FolderPath, "muscles.csv");
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(FolderPath);
                File.Create(FilePath).Dispose();
                string data = $"MuscleId,Name,VolumePerWeek";
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }

        }
        public void Add(Muscle muscle)
        {
            int muscleId = RepositoryHelper.GetHighestId(FilePath) + 1;
            string data = $"{muscleId},{muscle.Name},{muscle.RecommendedVolumePerWeek}";
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(data);
            }
        }
        public void Delete(int muscleId)
        {
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);

            bool muscleDeleted = false;

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');

                if (fields.Length >= 2)
                {
                    int currentMuscleId = int.Parse(fields[0]);

                    if (currentMuscleId == muscleId)
                    {
                        lines.RemoveAt(i);
                        muscleDeleted = true;
                    }
                }
            }

            if (muscleDeleted)
            {
                // Aktualisierte Daten zurück in die CSV-Datei schreiben
                File.WriteAllLines(FilePath, lines);
            }
            else
            {
                throw new Exception("MuscleId not found");
            }
        }
        public List<Muscle> GetAll()
        {
            List<Muscle> muscles = new List<Muscle>();

            using (StreamReader reader = new StreamReader(FilePath))
            {
                // Überspringen der Kopfzeile
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length >= 5)
                    {
                        int muscleId = int.Parse(fields[0]);
                        string musclename = fields[1];
                        int volumePerWeek= int.Parse(fields[2]);

                        Muscle muscle = new Muscle(musclename, volumePerWeek);
                        muscle.Id = muscleId;
                        muscles.Add(muscle);
                    }
                }


            }

            return muscles;
        }
        public Muscle GetById(int muscleId)
        {
            Muscle? muscle = null;
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');


                if (fields.Length >= 2)
                {
                    int currentMuscleId = int.Parse(fields[0]);

                    if (currentMuscleId == muscleId)
                    {
                        string musclename = fields[1];
                        int volumePerWeek = int.Parse(fields[2]);

                        muscle = new Muscle(musclename, volumePerWeek);
                        muscle.Id = muscleId;
                    }
                }
            }

            if (muscle != null)
            {
                return muscle;
            }
            else
            {
                throw new Exception("MuscleId not found");
            }
        }
        public Muscle GetByName(string name)
        {
            Muscle? muscle = null;
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');


                if (fields.Length >= 2)
                {
                    string currentName = fields[1];

                    if (currentName.Equals(name))
                    {
                        int muscleId = int.Parse(fields[0]);
                        int volumePerWeek = int.Parse(fields[2]);

                        muscle = new Muscle(name, volumePerWeek);
                        muscle.Id = muscleId;
                    }
                }
            }

            if (muscle != null)
            {
                return muscle;
            }
            else
            {
                throw new Exception("MuscleId not found");
            }
        }
        public void Update(Muscle muscle)
        {
            Delete(muscle.Id);
            string data = $"{muscle.Id},{muscle.Name},{muscle.RecommendedVolumePerWeek}";
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(data);
            }
        }
        
    }
}
