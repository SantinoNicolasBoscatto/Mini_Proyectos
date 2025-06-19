using ConsoleApp1.Patrones.Observer._Exercises.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Observer._Exercises.Concrete_Observer
{
    public class Customer : IObserverSubastas
    {
        private bool _winning = false;
        private string _name;
        public Customer(string name)
        {
            _name = name;
        }

        public void Update(bool winning)
        {
            _winning = winning;
            if(!_winning) Display();
        }

        public void Display()
        {
            Console.WriteLine(_name+" Se coloco un nuevo precio sobre el objeto subastado");
        }
    }
}
