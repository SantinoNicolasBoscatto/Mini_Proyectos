using ConsoleApp1.Patrones.Bridge.Abstraction;
using ConsoleApp1.Patrones.Bridge.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Bridge
{
    public class DesktopPlayer : MusicPlayer
    {
        // Por constructor le paso a la clase MusicPlayer la interfaz que necesita para su construccion.
        public DesktopPlayer(IFormat format) : base(format)
        {}

        // llamamos al _format y ejecutamos el metodo Play, que dependera del formato que le pasemos al constructor
        public override void Play(string path)
        {
            Console.WriteLine("Using Desktop");
            _format.Play(path);
        }
    }
}
