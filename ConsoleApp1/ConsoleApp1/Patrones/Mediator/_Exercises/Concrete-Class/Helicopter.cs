using ConsoleApp1.Patrones.Mediator._Exercises.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Mediator._Exercises.Concrete_Class
{
    public class Helicopter : Aircraft
    {
        public Helicopter(IMediatorTower tower, string name) : base(tower, name)
        {}
    }
}
