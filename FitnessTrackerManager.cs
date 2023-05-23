using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class FitnessTrackerManager
    {
        public Athlete? User;
        public IUserInteraction ui;
        public IDbManager db;
        public FitnessTrackerManager(IUserInteraction ui, IDbManager db)
        {
            this.ui = ui;
            this.db = db;
        }
        public void Start()
        {
            ui.Write("Welcome to Fitnesstracker!");
            ui.Write("Please enter your Username:");
            string? username = null;
            while(username == null)
            {
                username = ui.Read();

            }
            this.User = this.LoginSuccessful(username);
            this.StartMenu();
        }
        public void Stop()
        {
            ui.Write("Exiting...");
            Environment.Exit(0);
        }
        public Athlete LoginSuccessful(string username)
        {
            if (db.UsernameExists(username))
            {
                ui.Write("Please enter your Password:");
                while (true)
                {
                    string? password = ui.Read();
                    if (password != null)
                    {
                        if (db.PasswordCorrect(username, password))
                        {
                            return db.GetAthleteByUsername(username);

                        }
                        else
                        {
                            ui.Write("Wrong password");

                        }
                    }
                }
            } else
            {
                return this.CreateAccount(username);
            }
        }
        public Athlete CreateAccount(string username)
        {
            return db.GetAthleteByUsername(username);
        }
        public void StartMenu()
        {
            while(true)
            {
                ui.Write("1: Start new Workout");
                ui.Write("2: Recent Workouts");
                ui.Write("X: Exit");
                switch (ui.Read())
                {
                    case "1":
                        StartWorkout();
                        break;
                    case "2":
                        ViewRecentWorkouts();
                        break;
                    case "x":
                    case "X":
                        this.Stop();
                        break;
                    default:
                        break;
                }
            }            
        }
        public void StartWorkout()
        {
            ui.Write("this is a new workout");
        }
        public void ViewRecentWorkouts()
        {
            ui.Write("Recent Workouts");
        }
    }
}
