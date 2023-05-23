// See https://aka.ms/new-console-template for more information
using FitnessTracker;
var ui = new UserInteraction();
var db = new DbManager();
var fitnesstracker = new FitnessTrackerManager(ui, db);

fitnesstracker.Start();
