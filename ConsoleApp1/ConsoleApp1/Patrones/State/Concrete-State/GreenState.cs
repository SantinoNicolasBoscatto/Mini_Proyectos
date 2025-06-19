using ConsoleApp1.Patrones.State.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.State.Concrete_State
{
    public class GreenState : IState.IState
    {
        public void Handle(StateContext state)
        {
            Console.WriteLine("Green");
            // Debo definir el estado siguiente
            state.CurrentState = new YellowState();
        }
    }
}
