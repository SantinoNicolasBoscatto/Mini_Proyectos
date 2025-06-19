using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Patrones.Bridge.Implementation;

namespace ConsoleApp1.Patrones.Bridge.Concrete_Class
{
    public class MP3 : IFormat
    {
        public void Play(string path)
        {
            Console.WriteLine("MP3: "+ path);
        }
    }
}
