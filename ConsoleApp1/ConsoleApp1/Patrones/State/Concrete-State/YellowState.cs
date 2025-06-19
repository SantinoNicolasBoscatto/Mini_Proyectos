using ConsoleApp1.Patrones.State.Context;
using ConsoleApp1.Patrones.State.IState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.State.Concrete_State
{
    public class YellowState : IState.IState
    {
        public void Handle(StateContext state)
        {
            Console.WriteLine("Yellow");
            state.CurrentState = new RedState();
        }
    }
}
