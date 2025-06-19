using ConsoleApp1.Patrones.Command._Exercise.Command;
using ConsoleApp1.Patrones.Command._Exercise.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Command._Exercise.Concrete_Command
{
    public class NetfilxConcreteCommand : ICommand
    {
        private SmartTV controller;
        public NetfilxConcreteCommand(SmartTV controller)
        {
            this.controller = controller;
        }

        public void Execute()
        {
            controller.AccessNetflix();
        }
    }
}
