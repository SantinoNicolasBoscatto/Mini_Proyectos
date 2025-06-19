using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Facade.SubSystems
{
    public class Speakers
    {
        public void On()
        {
            Console.WriteLine("Speaker Se prende");
        }

        public void Off()
        {
            Console.WriteLine("Speaker Se apaga");
        }
    }
}
