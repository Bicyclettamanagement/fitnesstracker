using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private const string FilePath = @"data\workouts.csv";

        public void Add(Workout workout)
        {
            int workoutId = GetHighestId() +1;
            foreach (var exercise in workout.PerformedExercises)
            {
                string data = $"{workoutId}{workout.UserId},{workout.Name}{workout.Date},{exercise},{exercise.Repetitions},{exercise.Weight}";

                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
        }

        public void Delete(int workoutId)
        {
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);

            bool workoutDeleted = false;

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');

                if (fields.Length >= 2)
                {
                    int currentWorkoutId = int.Parse(fields[0]);

                    if (currentWorkoutId == workoutId)
                    {
                        lines.RemoveAt(i);
                        workoutDeleted = true;
                    }
                }
            }

            if (workoutDeleted)
            {
                // Aktualisierte Daten zurück in die CSV-Datei schreiben
                File.WriteAllLines(FilePath, lines);
            }
            else
            {
                throw new Exception("WorkoutId not found");
            }
        }

        public List<Workout> GetAllWorkouts()
        {
            List<Workout> workouts = new List<Workout>();

            using (StreamReader reader = new StreamReader(FilePath))
            {
                // Überspringen der Kopfzeile
                reader.ReadLine();

                // Dictionary zur temporären Speicherung der Workout-IDs und zugehörigen Workouts erstellen
                Dictionary<int, Workout> workoutDictionary = new Dictionary<int, Workout>();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length >= 5)
                    {
                        int workoutId = int.Parse(fields[0]);
                        string name = fields[1];
                        DateTime date = DateTime.Parse(fields[2]);
                        int exerciseId = int.Parse(fields[3]);
                        int repetitions = int.Parse(fields[4]);
                        int weight = int.Parse(fields[5]);
                        var exercise = new PerformedExercise(exerciseId, repetitions, weight);

                        
                        if (!workoutDictionary.ContainsKey(workoutId))
                        {
                            Workout workout = new Workout(workoutId, name, date);
                            workoutDictionary.Add(workoutId, workout);
                        }

                        workoutDictionary[workoutId].AddExercise(exercise);
                    }
                }

                workouts.AddRange(workoutDictionary.Values);
            }

            return workouts;
        }

        public Workout GetById(int workoutId)
        {
            Workout? workout = null;
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');
                

                if (fields.Length >= 2)
                {
                    int currentWorkoutId = int.Parse(fields[0]);

                    if (currentWorkoutId == workoutId)
                    {
                        if (workout == null)
                        {
                            string name = fields[1];
                            DateTime date = DateTime.Parse(fields[2]);
                            workout = new Workout(workoutId, name, date);
                        }
                        
                        int exerciseId = int.Parse(fields[3]);
                        int repetitions = int.Parse(fields[4]);
                        int weight = int.Parse(fields[5]);
                        var exercise = new PerformedExercise(exerciseId, repetitions, weight);
                        workout.AddExercise(exercise);

                        
                        
                    }
                }
            }

            if (workout != null)
            {
                return workout;
            }
            else
            {
                throw new Exception("WorkoutId not found");
            }
        }


        public void Update(Workout workout)
        {
            Delete(workout.Id);
            foreach (var exercise in workout.PerformedExercises)
            {
                string data = $"{workout.Id}{workout.UserId},{workout.Name}{workout.Date},{exercise},{exercise.Repetitions},{exercise.Weight}";

                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }

        }
        private int GetHighestId()
        {
            int highestId = 0;

            using (StreamReader reader = new StreamReader("workouts.csv"))
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
