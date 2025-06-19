using ConsoleApp1.Patrones.Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Decorator.Concrete_Class
{
    public class SimpleCoffee : ICoffee
    {
        public double GetCost()
        {
            return 1.0;
        }

        public string GetDescription()
        {
            return "Simple Coffee";
        }
    }
}
