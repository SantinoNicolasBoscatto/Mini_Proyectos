using ConsoleApp1.Patrones.Strategy.IStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Strategy.Concrete_Class
{
    public class ShortRouteStrategy : IRouteStrategy
    {
        public string CalculateRoute(string A, string B)
        {
            return "La ruta mas corta es...";
        }
    }
}
