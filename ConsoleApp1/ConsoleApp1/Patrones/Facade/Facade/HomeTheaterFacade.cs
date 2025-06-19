using ConsoleApp1.Patrones.Facade.SubSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Facade.Facade
{
    public class HomeTheaterFacade
    {
        private DvdPlayer _dvdPlayer;
        private Projector _projector;
        private Speakers _speakers;
        public HomeTheaterFacade(DvdPlayer dvdPlayer, Projector projector, Speakers speakers)
        {
            _dvdPlayer = dvdPlayer;
            _projector = projector;
            _speakers = speakers;
        }

        public void WatchMovie()
        {
            Console.WriteLine("Encendiendo Home");
            _projector.On();
            _speakers.On();
            _dvdPlayer.On();
            _dvdPlayer.PlayMovie("Cars 1");
        }

        public void EndMovie()
        {
            Console.WriteLine("Apagando Home");
            _projector.Off();
            _speakers.Off();
            _dvdPlayer.Off();
        }
    }
}
