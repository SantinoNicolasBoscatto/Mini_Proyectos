using ConsoleApp1.Patrones.Composite._Exercises.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Composite._Exercises.Concrete_Class
{
    public class Manager : IWorker
    {
        private string _name;
        private List<IWorker> _workers;
        public Manager(string name)
        {
            _workers = new List<IWorker>();
            _name = name;
        }

        public void Display(string identar = "")
        {
            Console.WriteLine($"{identar}- {_name}");
            foreach (var worker in _workers)
            {
                worker.Display(identar + "  ");
            }
        }


        public void Add(IWorker worker)
        {
            _workers.Add(worker);
        }
    }
}
