using ConsoleApp1.Patrones.Strategy.IStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Strategy.Navigator
{
    public class NavigatorContext
    {
        private IRouteStrategy _routeStrategy;
        public NavigatorContext(IRouteStrategy routeStrategy)
        {
            _routeStrategy = routeStrategy;
        }

        // Esto me permitira cambiar el Strategy en tiempo de ejecucion, esta es la base del patron 
        // Strategy, cambiar de bloque de codigo, en este caso setear distintas clases concretas que 
        // implementen IRouteStrategy, lo que me permitira ejecutar implementaciones unica, ya que
        // estas Concrete-Class tendran el mismo metodo pero diferentemente implementado.
        public void SetStrategy(IRouteStrategy strategy)
        {
            _routeStrategy = strategy;
        }

        public void Executetrategy(string A, string B)
        {
            var result = _routeStrategy.CalculateRoute(A, B);
            Console.WriteLine(result);
        }
    }
}
