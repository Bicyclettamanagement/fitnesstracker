using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class FitnessTrackerClient
    {
        public Athlete? User;
        public IUserInteraction ui;
        public IDbManager db;
        public FitnessTrackerClient(IUserInteraction ui, IDbManager db)
        {
            this.ui = ui;
            this.db = db;
            
        }
        public Athlete Login(string username)
        {
            ui.Write("Please enter your Password:");
            while (true)
            {
                string? password = ui.Read();
                if (password != null)
                {
                    if (db.PasswordCorrect(username, password)) { return db.GetAthleteByUsername(username); }
                    else { ui.Write("Wrong password"); }

                }
            }
            
            
        }
        public Athlete CreateAccount(string username)
        {
            return db.GetAthleteByUsername(username);
        }

    }
}
