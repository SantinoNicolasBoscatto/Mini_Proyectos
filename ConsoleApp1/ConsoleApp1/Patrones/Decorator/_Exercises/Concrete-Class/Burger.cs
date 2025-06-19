using ConsoleApp1.Patrones.Decorator._Exercises.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Decorator._Exercises.Concrete_Class
{
    public class Burger : IBurger
    {
        public double getBurgerCost()
        {
            return 5.5;
        }

        public string getBurgerDescription()
        {
            return "Simple Burger";
        }
    }
}
