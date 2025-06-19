using ConsoleApp1.Patrones.State.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.State.Concrete_State
{
    public class RedState : IState.IState
    {
        public void Handle(StateContext state)
        {
            Console.WriteLine("Red");
            state.CurrentState = new GreenState();
        }
    }
}
