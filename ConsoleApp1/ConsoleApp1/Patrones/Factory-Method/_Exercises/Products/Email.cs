using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Factory_Method._Exercises.Products
{
    public class Email : IMessage
    {
        public void Send(string msg)
        {
            Console.WriteLine("Esto es un mensaje de Email: "+ msg);
        }
    }
}
