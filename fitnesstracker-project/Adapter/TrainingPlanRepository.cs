using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private const string FilePath = @"./data/trainingPlans.csv";
        //TrainingPlan(string name, List<Exercise> exercises)
        public void Save(TrainingPlan trainingPlan)
        {
            int trainingPlanId = GetHighestId() + 1;
            foreach (var exercise in trainingPlan.Exercises)
            {
                string data = $"{trainingPlanId}{trainingPlan.Name},{exercise}";

                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
        }

        public void Delete(int trainingPlanId)
        {
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);

            bool trainingPlanDeleted = false;

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');

                if (fields.Length >= 2)
                {
                    int currentTrainingPlanId = int.Parse(fields[0]);

                    if (currentTrainingPlanId == trainingPlanId)
                    {
                        lines.RemoveAt(i);
                        trainingPlanDeleted = true;
                    }
                }
            }

            if (trainingPlanDeleted)
            {
                // Aktualisierte Daten zurück in die CSV-Datei schreiben
                File.WriteAllLines(FilePath, lines);
            }
            else
            {
                throw new Exception("TrainingPlanId not found");
            }
        }
        public List<TrainingPlan> GetAll()
        {
            List<TrainingPlan> trainingPlans = new List<TrainingPlan>();

            using (StreamReader reader = new StreamReader(FilePath))
            {
                // Überspringen der Kopfzeile
                reader.ReadLine();

                // Dictionary zur temporären Speicherung der Workout-IDs und zugehörigen Workouts erstellen
                Dictionary<int, TrainingPlan> trainingPlanDictionary = new Dictionary<int, TrainingPlan>();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length >= 5)
                    {
                        int trainingPlanId = int.Parse(fields[0]);
                        string name = fields[1];
                        int exerciseId = int.Parse(fields[2]);
                        
                        if (!trainingPlanDictionary.ContainsKey(trainingPlanId))
                        {
                            TrainingPlan trainingPlan = new TrainingPlan(name);
                            trainingPlan.Id = trainingPlanId;
                            trainingPlanDictionary.Add(trainingPlanId, trainingPlan);
                        }

                        trainingPlanDictionary[trainingPlanId].AddExercise(exerciseId);
                    }
                }

                trainingPlans.AddRange(trainingPlanDictionary.Values);
            }

            return trainingPlans;
        }

        public TrainingPlan GetById(int trainingPlanId)
        {
            TrainingPlan? trainingPlan = null;
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');


                if (fields.Length >= 2)
                {
                    int currentTrainingPlanId = int.Parse(fields[0]);

                    if (currentTrainingPlanId == trainingPlanId)
                    {
                        if (trainingPlan == null)
                        {
                            string name = fields[1];
                            trainingPlan = new TrainingPlan(name);
                            trainingPlan.Id = trainingPlanId;
                        }

                        int exerciseId = int.Parse(fields[2]);
                        trainingPlan.AddExercise(exerciseId);



                    }
                }
            }

            if (trainingPlan != null)
            {
                return trainingPlan;
            }
            else
            {
                throw new Exception("TrainingPlanId not found");
            }
        }


        public void Update(TrainingPlan trainingPlan)
        {
            Delete(trainingPlan.Id);
            foreach (var exercise in trainingPlan.Exercises)
            {
                string data = $"{trainingPlan.Id}{trainingPlan.Name},{exercise}";

                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
        }

        
        private int GetHighestId()
        {
            int highestId = 0;

            using (StreamReader reader = new StreamReader("trainingPlans.csv"))
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
