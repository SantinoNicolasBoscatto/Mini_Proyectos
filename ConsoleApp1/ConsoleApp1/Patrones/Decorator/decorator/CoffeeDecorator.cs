using ConsoleApp1.Patrones.Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Decorator.decorator
{
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;
        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        // La palabra reservada VIRTUAL me permite poder sobrescribir el metodo si lo requiero
        public virtual double GetCost()
        {
           return _coffee.GetCost();
        }

        public virtual string GetDescription()
        {
           return _coffee.GetDescription();
        }
    }
}
