using ConsoleApp1.Patrones.Command.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Command.Invoker
{
    public class Waiter
    {
        public void TakeCommand(IComand comand)
        {
            comand.Execute();
        }
    }
}
