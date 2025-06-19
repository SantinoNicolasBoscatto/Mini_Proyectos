using ConsoleApp1.Patrones.Decorator.Component;
using ConsoleApp1.Patrones.Decorator.decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Decorator.Concrete_Decorators
{
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {}

        // Overraideo los metodos, tomo el valor original y le sumo un cambio, por ejemplo pido el valor base del cafe que 
        // pedi pero ademas le hago un recargo, Lo mismo con la descripcion. De ahi viene el nombre de decorador, al 
        // agregarle cosas a un elemento base, lo decora.
        public override double GetCost()
        {
            return _coffee.GetCost() + 0.5;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription()+", With milk";
        }
    }
}
