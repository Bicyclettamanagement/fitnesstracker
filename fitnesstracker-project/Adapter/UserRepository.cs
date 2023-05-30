using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Adapter
{
    public class UserRepository : IUserRepository
    {
        private const string FilePath = @"data\users.csv";
        public void Create(User user)
        {
            int userId = GetHighestId() + 1;

            string data = $"{userId}{user.Username},{user.Password}{user.Birthday.ToShortDateString},{user.Weight}";

            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(data);
            }

        }

        public bool Exists(string username)
        {
            bool exists = false;
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');


                if (fields.Length >= 2)
                {
                    string currentUsername = fields[1];

                    if (currentUsername.Equals(username))
                    {
                        exists = true;
                        break;
                    }
                }
            }
            return exists;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

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
                        int userId = int.Parse(fields[0]);
                        string username = fields[1];
                        string password = fields[2];
                        DateTime birthday = DateTime.Parse(fields[3]);
                        float weight = float.Parse(fields[3]);

                        User user = new User(username, password, birthday, weight);
                        user.Id = userId;
                        users.Add(user);
                    }
                }


            }

            return users;
        }

        public User GetById(int userId)
        {
            User? user = null;
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');


                if (fields.Length >= 2)
                {
                    int currentUserId = int.Parse(fields[0]);

                    if (currentUserId == userId)
                    {
                        string username = fields[1];
                        string password = fields[2];
                        DateTime birthday = DateTime.Parse(fields[3]);
                        float weight = float.Parse(fields[3]);

                        user = new User(username, password, birthday, weight);
                        user.Id = userId;

                    }
                }
            }

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("UserId not found");
            }
        }

        public User GetUserByUsername(string username)
        {
            User? user = null;
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');


                if (fields.Length >= 2)
                {
                    string currentUsername = fields[0];

                    if (currentUsername.Equals(username))
                    {
                        int userId = int.Parse(fields[0]);
                        string password = fields[2];
                        DateTime birthday = DateTime.Parse(fields[3]);
                        float weight = float.Parse(fields[3]);

                        user = new User(username, password, birthday, weight);
                        user.Id = userId;

                    }
                }
            }

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("Username not found");
            }
        }
        public void Delete(int userId)
        {
            List<string> lines = File.ReadAllLines(FilePath).ToList();

            // Überspringen der Kopfzeile
            lines.RemoveAt(0);

            bool userDeleted = false;

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string line = lines[i];
                string[] fields = line.Split(',');

                if (fields.Length >= 2)
                {
                    int currentUserId = int.Parse(fields[0]);

                    if (currentUserId == userId)
                    {
                        lines.RemoveAt(i);
                        userDeleted = true;
                    }
                }
            }
            if (userDeleted)
            {
                // Aktualisierte Daten zurück in die CSV-Datei schreiben
                File.WriteAllLines(FilePath, lines);
            }
            else
            {
                throw new Exception("UserId not found");
            }
        }

        public void Update(User user)
        {
            Delete(user.Id);
            string data = $"{user.Id}{user.Username},{user.Password}{user.Birthday.ToShortDateString},{user.Weight}";

            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(data);
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
