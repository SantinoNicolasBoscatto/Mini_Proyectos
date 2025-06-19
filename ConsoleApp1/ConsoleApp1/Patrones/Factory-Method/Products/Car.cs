using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Factory_Method.Products
{
    public class Car : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Brum");
        }

        public void Stop()
        {
            Console.WriteLine("Stop Car");
        }
    }
}
