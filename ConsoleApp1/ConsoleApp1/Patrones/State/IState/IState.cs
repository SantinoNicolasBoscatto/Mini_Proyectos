using ConsoleApp1.Patrones.State.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.State.IState
{
    public interface IState
    {
        void Handle(StateContext state);
    }
}
