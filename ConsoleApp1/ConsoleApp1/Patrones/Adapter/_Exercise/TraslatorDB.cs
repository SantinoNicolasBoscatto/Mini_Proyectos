using ConsoleApp1.Patrones.Adapter._Exercise.Concrete_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter._Exercise
{
    public class TraslatorDB : ISaveDB
    {
        private NewSystem newSystem;
        public TraslatorDB(NewSystem newSystem)
        {
            this.newSystem = newSystem;
        }
        public void SaveDB(string data)
        {
            newSystem.SaveNewSystemBD(data);
        }
    }
}
