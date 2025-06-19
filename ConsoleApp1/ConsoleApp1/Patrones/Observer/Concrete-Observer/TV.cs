using ConsoleApp1.Patrones.Observer.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Observer.Concrete_Observer
{
    public class TV : IObserver
    {
        private float _temp;
        private float _humidity;
        private float _pressure;
        private string _name;

        public TV(string name)
        {
            _name = name;
        }

        public void Update(float temp, float humidity, float pressure)
        {
             _temp = temp;
            _humidity = humidity;
            _pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"{_name} show temp: "+ _temp);
        }
    }
}
