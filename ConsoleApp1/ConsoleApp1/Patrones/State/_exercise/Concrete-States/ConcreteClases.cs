using ConsoleApp1.Patrones.State._exercise.Context;
using ConsoleApp1.Patrones.State._exercise.IState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.State._exercise.Concrete_States
{
    public class WaitingSelectProduct : IStateVending
    {
        public void Handle(StateVendingContext context)
        {
            Console.WriteLine("Producto seleccionado");
            context.CurrentState = new WaitingPayProduct();
        }
    }

    public class WaitingPayProduct : IStateVending
    {
        public void Handle(StateVendingContext context)
        {
            Console.WriteLine("Pago realizado");
            context.CurrentState = new ReleasingProduct();
        }
    }

    public class ReleasingProduct : IStateVending
    {
        public void Handle(StateVendingContext context)
        {
            Console.WriteLine("Largando producto");
            context.CurrentState = new WaitingSelectProduct();
        }
    }
}
