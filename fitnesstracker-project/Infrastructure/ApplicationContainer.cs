using FitnessTracker.Adapter;
using FitnessTracker.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure
{
    public class AppContainer : IAppContainer
    {
        private readonly IExerciseRepository exerciseRepository;
        private readonly IUserRepository userRepository;
        private readonly IWorkoutRepository workoutRepository;
        private readonly ITrainingPlanRepository trainingPlanRepository;

        public AppContainer(IExerciseRepository exerciseRepository, IUserRepository userRepository, IWorkoutRepository workoutRepository, ITrainingPlanRepository trainingPlanRepository)
        {
            this.exerciseRepository = exerciseRepository;
            this.userRepository = userRepository;
            this.workoutRepository = workoutRepository;
            this.trainingPlanRepository = trainingPlanRepository;
        }

        public ExerciseService CreateExerciseService()
        {
            return new ExerciseService(exerciseRepository);
        }

        public UserService CreateUserService()
        {
            return new UserService(userRepository);
        }

        public WorkoutService CreateWorkoutService()
        {
            return new WorkoutService(workoutRepository);
        }

        public AuthenticationService CreateAuthenticationService()
        {
            return new AuthenticationService(userRepository);
        }

        public TrainingPlanService CreateTrainingPlanService()
        {
            return new TrainingPlanService(trainingPlanRepository);
        }
    }

}
