using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter.Concrete_Class
{
    public class EnglishSpeaker : ICommunication
    {
        public void Ask(string question)
        {
           Console.WriteLine(question);
        }

        public void Reply(string answer)
        {
            Console.WriteLine(answer);
        }
    }
}
