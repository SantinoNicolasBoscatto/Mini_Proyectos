using ConsoleApp1.Patrones.Command.Command;
using ConsoleApp1.Patrones.Command.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Command.Concrete_Command
{
    public class CancelConcreteCommand : IComand
    {
        private Order order;
        public CancelConcreteCommand(Order order)
        {
            this.order = order;
        }

        public void Execute()
        {
            order.Cancel();
        }
    }
}
