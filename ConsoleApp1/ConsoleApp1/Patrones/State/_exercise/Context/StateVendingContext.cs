using ConsoleApp1.Patrones.State._exercise.Concrete_States;
using ConsoleApp1.Patrones.State._exercise.IState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.State._exercise.Context
{
    public class StateVendingContext
    {
        public IStateVending CurrentState { get; set; }
        public StateVendingContext(IStateVending currentState)
        {
            CurrentState = currentState;
        }

        public void SelectProduct()
        {
            if (CurrentState is WaitingSelectProduct)CurrentState.Handle(this);
            else Console.WriteLine("Invalid Action");
        }

        public void InsertPayment()
        {
            if (CurrentState is WaitingPayProduct) CurrentState.Handle(this);
            else Console.WriteLine("Invalid Action");
        }

        public void WaitRealese()
        {
            if (CurrentState is ReleasingProduct) CurrentState.Handle(this);
            else Console.WriteLine("Invalid Action");
        }
    }
}
