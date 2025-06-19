using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Factory_Method.Products
{
    public class Motorbike : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Bram Bram");
        }

        public void Stop()
        {
            Console.WriteLine("Stop Motorbike");
        }
    }
}
