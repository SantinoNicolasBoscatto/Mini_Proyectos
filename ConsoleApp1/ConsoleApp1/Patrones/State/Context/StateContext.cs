using ConsoleApp1.Patrones.State.IState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.State.Context
{
    public class StateContext
    {
        public IState.IState CurrentState { get; set; }
        public StateContext(IState.IState currentState)
        {
            CurrentState = currentState;
        }

        public void Request()
        {
            CurrentState.Handle(this);
        }
    }
}
