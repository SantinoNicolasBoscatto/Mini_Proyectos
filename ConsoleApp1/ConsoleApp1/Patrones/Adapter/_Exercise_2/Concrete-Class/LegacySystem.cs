using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter._Exercise_2.Concrete_Class
{
    public class LegacySystem
    {
        public void InsertData(string data)
        {
            Console.WriteLine("Legacy data: "+ data);
        }

        public string GetData()
        {
            return "Data from legacy DB";
        }
    }
}
