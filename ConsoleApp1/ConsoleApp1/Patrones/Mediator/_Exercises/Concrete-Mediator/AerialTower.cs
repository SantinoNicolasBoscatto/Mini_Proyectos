using ConsoleApp1.Patrones.Mediator._Exercises.Concrete_Class;
using ConsoleApp1.Patrones.Mediator._Exercises.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Mediator._Exercises.Concrete_Mediator
{
    public class AerialTower : IMediatorTower
    {
        private List<Aircraft> aircraftList = new List<Aircraft>();

        // Esta funcion registra elementos aereos en una lista
        public void RegisterAircraft(Aircraft aircraft)
        {
            if(!aircraftList.Contains(aircraft))
            {
                aircraftList.Add(aircraft);
            }
        }

        public void Notify(Aircraft sender, string eventCode)
        {
            foreach (var item in aircraftList)
            {
                if(item != sender)
                    item.ReceiveMessage(eventCode);
            }
        }
    }
}
