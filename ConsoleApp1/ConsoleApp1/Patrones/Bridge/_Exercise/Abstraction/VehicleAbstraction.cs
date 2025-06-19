using ConsoleApp1.Patrones.Bridge._Exercise.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Bridge._Exercise.Abstraction
{
    public abstract class VehicleAbstraction
    {
        protected IEngine _engine;
        public VehicleAbstraction(IEngine engine)
        {
            _engine = engine;
        }
        public abstract void Drive();
    }
}
