using FitnessTracker.Adapter;
using FitnessTracker.Domain;
using FitnessTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class CreateWorkoutUseCase
    {
        private readonly IAppContainer _appContainer;
        public CreateWorkoutUseCase(IAppContainer appContainer)
        {
            _appContainer = appContainer;
        }
        public Workout CreateManualWorkout(string workoutName)
        {
            return new Workout(_appContainer.CreateWorkoutService());
        }
        public List<Exercise> GetAvailableExercises()
        {
            ExerciseService exerciseService = _appContainer.CreateExerciseService();
            return exerciseService.GetAllExercises();
        }
        public Muscle GetMuscleById(int id)
        {
            MuscleService muscleService = _appContainer.CreateMuscleService();
            return muscleService.GetMuscleById(id);
        }
        public Exercise GetExerciseById(int id)
        {
            ExerciseService exerciseService = _appContainer.CreateExerciseService();
            return exerciseService.GetExerciseById(id);
        }
        public List<TrainingPlan> GetAllTrainingPlans()
        {
            TrainingPlanService trainingPlanService = _appContainer.CreateTrainingPlanService();
            return trainingPlanService.GetTrainingPlans();
        }
        public void Save(Workout workout)
        {
            WorkoutService workoutService = _appContainer.CreateWorkoutService();
            workoutService.SaveWorkout(workout);
        }
        public void SaveAsTrainingPlan(Workout workout) 
        {
            TrainingPlan trainingPlan = new(workout.Name);
            foreach(PerformedExercise performedExercise in workout.PerformedExercises)
            {
                trainingPlan.AddExercise(performedExercise.ExerciseId);
            }
            TrainingPlanService trainingPlanService = _appContainer.CreateTrainingPlanService();
            trainingPlanService.CreateTrainingPlan(trainingPlan);
        }
    }
}
