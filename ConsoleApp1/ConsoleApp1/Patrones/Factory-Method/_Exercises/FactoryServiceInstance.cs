using ConsoleApp1.Patrones.Factory_Method._Exercises.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Factory_Method._Exercises
{
    public class FactoryServiceInstance
    {
        private IMessageFactory messageFactory;
        public FactoryServiceInstance(IMessageFactory messageFactory)
        {
            this.messageFactory = messageFactory;
        }

        public IMessage CreateMsg()
        {
           return messageFactory.CreateMessage();
        }
    }
}
