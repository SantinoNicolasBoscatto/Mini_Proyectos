using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Factory_Method._Exercises.Factories
{
    public interface IMessageFactory
    {
        IMessage CreateMessage();
    }
}
