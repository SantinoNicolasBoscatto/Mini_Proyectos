using ConsoleApp1.Patrones.Decorator._Exercises.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Decorator._Exercises.Decorator
{
    public abstract class BurgerDecorator : IBurger
    {
        protected IBurger _burger;

        protected BurgerDecorator(IBurger burger)
        {
            _burger = burger;
        }

        public virtual double getBurgerCost()
        {
            return _burger.getBurgerCost();
        }
        public virtual string getBurgerDescription()
        {
            return _burger.getBurgerDescription();
        }
    }
}
