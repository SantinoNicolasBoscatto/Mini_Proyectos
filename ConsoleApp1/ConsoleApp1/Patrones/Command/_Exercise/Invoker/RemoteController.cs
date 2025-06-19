using ConsoleApp1.Patrones.Command._Exercise.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Command._Exercise.Invoker
{
    public static class RemoteController
    {
        public static void TakeCommand(ICommand command)
        {
            command.Execute();
        }
    }
}
