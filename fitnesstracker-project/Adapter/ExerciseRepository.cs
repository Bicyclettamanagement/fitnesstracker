using FitnessTracker.Domain;
using FitnessTracker.Domain.Musclegroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class ExerciseRepository : IExerciseRepository
    {
        private const string FolderPath = @"./data/";
        private string FilePath;
        public ExerciseRepository()
        {
            this.FilePath = Path.Combine(FolderPath, "exercises.csv");
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(FolderPath);
                File.Create(FilePath).Dispose();
                string data = $"ExerciseId,Name,Description,Agonist,Synergist,IsUnilateral,OneRepMax";
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }

        }
        public void Add(Exercise exercise)
        {
            int exerciseId = GetHighestId() + 1;
            foreach (var agonist in exercise.Agonists)
            {
                // public Exercise(string name, string description, List<Muscle> agonists, List<Muscle> synergists, bool isUnilateral, int oneRepMax)
                string data = $"{exerciseId},{exercise.Name},{exercise.Description},{agonist},{""},{exercise.IsUnilateral},{exercise.OneRepMax}";
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
            foreach (var synergist in exercise.Synergists)
            {
                string data = $"{exerciseId},{exercise.Name},{exercise.Description},{""},{synergist},{exercise.IsUnilateral},{exercise.OneRepMax}";

                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
        }

        public void Delete(int exerciseId)
        {
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);

            bool exerciseDeleted = false;

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');

                if (fields.Length >= 2)
                {
                    int currentExerciseId = int.Parse(fields[0]);

                    if (currentExerciseId == exerciseId)
                    {
                        lines.RemoveAt(i);
                        exerciseDeleted = true;
                    }
                }
            }

            if (exerciseDeleted)
            {
                // Aktualisierte Daten zurück in die CSV-Datei schreiben
                File.WriteAllLines(FilePath, lines);
            }
            else
            {
                throw new Exception("ExerciseId not found");
            }
        }

        public List<Exercise> GetAll()
        {
            List<Exercise> exercises = new List<Exercise>();

            using (StreamReader reader = new StreamReader(FilePath))
            {
                // Überspringen der Kopfzeile
                reader.ReadLine();

                // Dictionary zur temporären Speicherung der Exercise-IDs und zugehörigen Exercises erstellen
                Dictionary<int, Exercise> exerciseDictionary = new Dictionary<int, Exercise>();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length >= 5)
                    {
                        int exerciseId = int.Parse(fields[0]);
                        string name = fields[1];
                        string description = fields[2];
                        int agonist = int.TryParse(fields[3], out agonist) ? agonist : -1;
                        int synergist = int.TryParse(fields[4], out synergist) ? synergist : -1;
                        bool isUnilateral = bool.Parse(fields[5]);
                        int oneRepMax = int.TryParse(fields[6], out oneRepMax) ? oneRepMax : -1;



                        if (!exerciseDictionary.ContainsKey(exerciseId))
                        {
                            Exercise exercise = new Exercise(name, description, isUnilateral, oneRepMax);
                            exercise.ExerciseId = exerciseId;
                            exerciseDictionary.Add(exerciseId, exercise);
                        }

                        if (agonist >= 0) exerciseDictionary[exerciseId].AddAgonist(agonist);
                        if (synergist >= 0) exerciseDictionary[exerciseId].AddSynergist(synergist);
                    }
                }

                exercises.AddRange(exerciseDictionary.Values);
            }

            return exercises;
        }

        public Exercise GetById(int exerciseId)
        {
            Exercise? exercise = null;
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');


                if (fields.Length >= 2)
                {
                    int currentExerciseId = int.Parse(fields[0]);

                    if (currentExerciseId == exerciseId)
                    {
                        if (exercise == null)
                        {

                            string name = fields[1];
                            string description = fields[2];
                            bool isUnilateral = bool.Parse(fields[5]);
                            int oneRepMax = int.TryParse(fields[6], out oneRepMax) ? oneRepMax : -1;
                            exercise = new Exercise(name, description, isUnilateral, oneRepMax);
                            exercise.ExerciseId = exerciseId;

                        }


                        int agonist = int.TryParse(fields[3], out agonist) ? agonist : -1;
                        int synergist = int.TryParse(fields[4], out synergist) ? synergist : -1;

                        if (agonist >= 0) exercise.AddAgonist(agonist);
                        if (synergist >= 0) exercise.AddSynergist(synergist);



                    }
                }
            }

            if (exercise != null)
            {
                return exercise;
            }
            else
            {
                throw new Exception("ExerciseId not found");
            }
        }

        public List<Exercise> GetExercisesByMuscle(int muscleId)
        {
            var exercises = GetAll();
            foreach (var exercise in exercises)
            {
                if (!exercise.Agonists.Contains(muscleId))
                {
                    exercises.Remove(exercise);
                }
            }

            return exercises;
        }



        public void Update(Exercise exercise)
        {
            Delete(exercise.ExerciseId);
            foreach (var agonist in exercise.Agonists)
            {
                // public Exercise(string name, string description, List<Muscle> agonists, List<Muscle> synergists, bool isUnilateral, int oneRepMax)
                string data = $"{exercise.ExerciseId}{exercise.Name},{exercise.Description}{agonist},{""},{exercise.IsUnilateral},{exercise.OneRepMax}";
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
            foreach (var synergist in exercise.Synergists)
            {
                string data = $"{exercise.ExerciseId}{exercise.Name},{exercise.Description}{""},{synergist},{exercise.IsUnilateral},{exercise.OneRepMax}";

                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
        }
        private int GetHighestId()
        {
            int highestId = 0;

            using (StreamReader reader = new StreamReader(FilePath))
            {
                // Überspringen der Kopfzeile
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length >= 2)
                    {
                        int workoutId = int.Parse(fields[0]);

                        if (workoutId > highestId)
                        {
                            highestId = workoutId;
                        }
                    }
                }
            }

            return highestId;
        }
    }
}
