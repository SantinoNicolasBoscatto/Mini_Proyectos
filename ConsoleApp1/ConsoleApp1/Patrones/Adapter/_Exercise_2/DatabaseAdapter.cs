using ConsoleApp1.Patrones.Adapter._Exercise_2.Concrete_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter._Exercise_2
{
    public class DatabaseAdapter : IDatabase
    {
        private LegacySystem _legacySystem;
        public DatabaseAdapter(LegacySystem legacySystem)
        {
            _legacySystem = legacySystem;
        }

        public void Add(string data)
        {
            _legacySystem.InsertData(data);
        }

        public string Retrieve()
        {
            return _legacySystem.GetData();
        }
    }
}
