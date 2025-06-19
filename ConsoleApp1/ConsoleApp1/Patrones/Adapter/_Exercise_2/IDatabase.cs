using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter._Exercise_2
{
    // Creo la interfaz Target
    public interface IDatabase
    {
        void Add(string data);
        string Retrieve();
    }
}
