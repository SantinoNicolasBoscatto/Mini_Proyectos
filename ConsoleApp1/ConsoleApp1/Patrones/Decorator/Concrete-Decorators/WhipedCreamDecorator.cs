using ConsoleApp1.Patrones.Decorator.Component;
using ConsoleApp1.Patrones.Decorator.decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Decorator.Concrete_Decorators
{
    public class WhipedCreamDecorator : CoffeeDecorator
    {
        public WhipedCreamDecorator(ICoffee coffee) : base(coffee)
        {}

        public override double GetCost()
        {
            return _coffee.GetCost() + 0.75;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", with Cream";
        }
    }
}
