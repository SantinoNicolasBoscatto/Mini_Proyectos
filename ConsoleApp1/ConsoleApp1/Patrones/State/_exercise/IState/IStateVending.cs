using ConsoleApp1.Patrones.State._exercise.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.State._exercise.IState
{
    public interface IStateVending
    {
        void Handle(StateVendingContext context);
    }
}
