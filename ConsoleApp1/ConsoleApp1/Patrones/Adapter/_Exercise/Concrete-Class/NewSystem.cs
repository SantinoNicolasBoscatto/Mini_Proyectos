using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter._Exercise.Concrete_Class
{
    public class NewSystem
    {
        public void SaveNewSystemBD(string data)
        {
            Console.WriteLine("Saving from new System data: "+data);
        }
    }
}
