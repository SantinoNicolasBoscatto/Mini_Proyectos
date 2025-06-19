using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter._Exercise.Concrete_Class
{
    public class LegacySystem : ISaveDB
    {
        public void SaveDB(string data)
        {
            Console.WriteLine("Saving the data in the old system: " + data);
        }
    }
}
