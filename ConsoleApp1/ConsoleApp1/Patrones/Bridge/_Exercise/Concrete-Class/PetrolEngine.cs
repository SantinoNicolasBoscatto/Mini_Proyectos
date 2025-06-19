using ConsoleApp1.Patrones.Bridge._Exercise.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Bridge._Exercise.Concrete_Class
{
    public class PetrolEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("BRUM");
        }

        public void Stop()
        {
            Console.WriteLine("Stop Petrol");
        }
    }
}
