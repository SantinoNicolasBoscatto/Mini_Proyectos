using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Decorator.Component
{
    // Defino la interfaz Component
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }
}
