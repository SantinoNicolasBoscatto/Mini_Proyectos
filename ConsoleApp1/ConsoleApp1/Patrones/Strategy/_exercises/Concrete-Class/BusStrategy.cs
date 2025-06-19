using ConsoleApp1.Patrones.Strategy._exercises.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Strategy._exercises.Concrete_Class
{
    public class BusStrategy : ITransportStrategy
    {
        public void GoToWork()
        {
            Console.WriteLine("Yendo en bus");
        }
    }
}
