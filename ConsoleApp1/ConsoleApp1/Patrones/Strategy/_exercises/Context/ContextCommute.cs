using ConsoleApp1.Patrones.Strategy._exercises.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Strategy._exercises.Context
{
    public class ContextCommute 
    {
        private ITransportStrategy _transportStrategy;
        public ContextCommute(ITransportStrategy transportStrategy)
        {
            _transportStrategy = transportStrategy;
        }

        public void SetStrategy(ITransportStrategy transportStrategy)
        {
            _transportStrategy = transportStrategy;
        }

        public void ExecuteStrategy()
        {
            _transportStrategy.GoToWork();
        }
    }
}
