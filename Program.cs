// See https://aka.ms/new-console-template for more information
using FitnessTracker;
var ui = new UserInteraction();
var db = new DbManager();
var fitnesstracker = new FitnessTrackerClient(ui, db);

fitnesstracker.Start();
