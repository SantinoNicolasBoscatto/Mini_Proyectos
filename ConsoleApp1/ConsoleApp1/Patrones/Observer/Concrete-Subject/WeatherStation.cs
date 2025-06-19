using ConsoleApp1.Patrones.Observer.Observer;
using ConsoleApp1.Patrones.Observer.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Observer.Concrete_Subject
{
    public class WeatherStation : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private float _temp;
        private float _humidity;
        private float _pressure;

        public void SetData(float temp, float humidity, float pressure)
        {
            _temp = temp;
            _humidity = humidity;
            _pressure = pressure;
            NotifyObservers();
        }
        public void NotifyObservers()
        {
            foreach (var item in _observers)
            {
                item.Update(_temp, _humidity, _pressure);
            }
        }
        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
           _observers.Remove(observer);
        }
    }
}
