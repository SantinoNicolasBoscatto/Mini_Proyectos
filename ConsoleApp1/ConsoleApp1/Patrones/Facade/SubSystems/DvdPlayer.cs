using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Facade.SubSystems
{
    public class DvdPlayer
    {
        public void On()
        {
            Console.WriteLine("Dvd Se prende");
        }

        public void Off()
        {
            Console.WriteLine("Dvd Se apaga");
        }

        public void PlayMovie(string movie)
        {
            Console.WriteLine($"Pongo peli: {movie}");
        }
    }
}
