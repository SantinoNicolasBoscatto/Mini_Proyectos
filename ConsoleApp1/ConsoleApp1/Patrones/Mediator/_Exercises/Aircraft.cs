using ConsoleApp1.Patrones.Mediator._Exercises.Concrete_Mediator;
using ConsoleApp1.Patrones.Mediator._Exercises.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Mediator._Exercises
{
    public abstract class Aircraft
    {
        // Inyecto aqui el Mediador directamente
        protected IMediatorTower _tower;
        protected string _name;

        protected Aircraft(IMediatorTower tower, string name)
        {
            _tower = tower;
            _name = name;
            // Cada vez que creo un Elemento aereo lo registro en la torre de control
            if(_tower is AerialTower concreteTower)
                concreteTower.RegisterAircraft(this);
        }

        // Metodo disparador del mediador
        public void SendMessage(string messge)
        {
            _tower.Notify(this, messge);
        }

        public void ReceiveMessage(string messge)
        {
            Console.WriteLine($"{_name} received message: {messge}");
        }
    }
}
