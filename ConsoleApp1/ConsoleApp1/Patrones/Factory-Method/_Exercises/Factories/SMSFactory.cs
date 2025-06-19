using ConsoleApp1.Patrones.Factory_Method._Exercises.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Factory_Method._Exercises.Factories
{
    public class SMSFactory : IMessageFactory
    {
        public IMessage CreateMessage()
        {
            return new SMS();
        }
    }
}
