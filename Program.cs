// See https://aka.ms/new-console-template for more information
using FitnessTracker;
var ui = new UserInteraction();
var db = new DbManager();
var fitnesstracker = new FitnessTrackerClient(ui, db);

while (true)
{

    ui.Write("Welcome to Fitnesstracker!");
    ui.Write("Please enter your Username:");
    string? username = ui.Read();
    
    if(username != null) 
    {
        if (db.UsernameExists(username))
        {
            fitnesstracker.Login(username);
        } else
        {
            fitnesstracker.CreateAccount(username);
        }
    }
}