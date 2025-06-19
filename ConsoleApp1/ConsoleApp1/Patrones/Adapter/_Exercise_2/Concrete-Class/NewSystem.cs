using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter._Exercise_2.Concrete_Class
{
    public class NewSystem
    {
        private IDatabase _database;
        public NewSystem(IDatabase database)
        {
            _database = database;
        }

        public void SaveData(string data)
        {
            _database.Add(data);
            Console.WriteLine("Saving the data in the new system: "+data);
        }

        public void LoadData()
        {
            string res = _database.Retrieve();
            Console.WriteLine("Data Loaded in the new system: "+ res);
        }
    }
}
