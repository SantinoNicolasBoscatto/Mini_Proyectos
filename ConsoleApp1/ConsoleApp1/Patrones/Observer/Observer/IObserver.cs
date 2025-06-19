using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Observer.Observer
{
    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }
}
