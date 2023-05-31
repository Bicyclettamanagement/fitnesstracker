using FitnessTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application
{
    public class MainMenuUseCase
    {
        private readonly IAppContainer _appContainer;
        public MainMenuUseCase(IAppContainer appContainer) 
        {
            _appContainer= appContainer;
        }
    }
}
