using FitnessTracker.Adapter;
using FitnessTracker.Application;
using FitnessTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure
{
    public class AppContainer : IAppContainer
    {
        public User? user;

        private readonly IExerciseRepository exerciseRepository;
        private readonly IUserRepository userRepository;
        private readonly IWorkoutRepository workoutRepository;
        private readonly ITrainingPlanRepository trainingPlanRepository;
        private readonly IMuscleRepository muscleRepository;

        public AppContainer(IExerciseRepository exerciseRepository, IUserRepository userRepository, IWorkoutRepository workoutRepository, ITrainingPlanRepository trainingPlanRepository, IMuscleRepository muscleRepository)
        {
            this.exerciseRepository = exerciseRepository;
            this.userRepository = userRepository;
            this.workoutRepository = workoutRepository;
            this.trainingPlanRepository = trainingPlanRepository;
            this.muscleRepository = muscleRepository;
        }
        public User GetUser() 
        {
            if (user != null) { return user; }
            else { throw new Exception("No user is currently logged in"); }
        }
        public void SetUser(User user) { this.user = user;}

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
        public MuscleService CreateMuscleService()
        {
            return new MuscleService(muscleRepository);
        }
    }

}
