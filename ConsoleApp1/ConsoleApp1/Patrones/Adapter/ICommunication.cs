using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter
{
    // Creo la interfaz de target
    public interface ICommunication
    {
        void Ask(string question);
        void Reply(string answer);
    }
}
