using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Strategy.IStrategy
{
    public interface IRouteStrategy
    {
        string CalculateRoute(string A, string B);
    }
}
