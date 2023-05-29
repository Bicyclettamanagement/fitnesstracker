using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Plugin
{
    public interface IUserInteraction
    {
        public void Write(string message);
        public string? Read();
    }
}
