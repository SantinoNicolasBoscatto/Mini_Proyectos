using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Facade.SubSystems
{
    public class Projector
    {
        public void On()
        {
            Console.WriteLine("Projector Se prende");
        }

        public void Off()
        {
            Console.WriteLine("Projector Se apaga");
        }
    }
}
