using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Mediator._Exercises.Mediator
{
    public interface IMediatorTower
    {
        void Notify(Aircraft sender, string eventCode);
    }
}
