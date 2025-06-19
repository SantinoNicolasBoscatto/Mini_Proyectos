using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Patrones.Bridge.Implementation;

namespace ConsoleApp1.Patrones.Bridge.Abstraction
{
    public abstract class MusicPlayer
    {
        protected IFormat _format;

        protected MusicPlayer(IFormat format)
        {
            _format = format;
        }

        // Con esto obligamos a que cualquier clase que implemente o herede a MusicPlayer a tener un Metodo Play
        public abstract void Play(string path);
    }
}
