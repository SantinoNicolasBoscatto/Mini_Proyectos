using ConsoleApp1.Patrones.Decorator._Exercises.Component;
using ConsoleApp1.Patrones.Decorator._Exercises.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Decorator._Exercises.Concrete_Decorator
{
    public class ChesseDecorator : BurgerDecorator
    {
        public ChesseDecorator(IBurger burger) : base(burger)
        {}

        public override double getBurgerCost()
        {
            return _burger.getBurgerCost() + 1.25;
        }

        public override string getBurgerDescription()
        {
            return _burger.getBurgerDescription() + ", with chesse";
        }
    }
}
