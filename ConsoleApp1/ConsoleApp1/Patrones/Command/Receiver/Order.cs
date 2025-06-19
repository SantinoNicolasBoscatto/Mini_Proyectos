using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Command.Receiver
{
    public class Order
    {
        public void Place()
        {
            Console.WriteLine("Orden Agregada");
        }

        public void Cancel()
        {
            Console.WriteLine("Orden Cancelada");
        }
    }
}
