using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter._Exercise
{
    public class SavingSystem
    {
        private readonly ISaveDB saveBD;

        public SavingSystem(ISaveDB saveBD)
        {
            this.saveBD = saveBD;
        }

        public void MakeSave(string data)
        {
            saveBD.SaveDB(data);
        }
    }
}
