using ConsoleApp1.Patrones.Composite._Exercises.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Composite._Exercises.Concrete_Class
{
    public class Employee : IWorker
    {
        private string _name;
        public Employee(string name)
        {
            _name = name;
        }

        public void Display(string identar = "")
        {
            Console.WriteLine($"{identar}- {_name}");
        }
    }
}
