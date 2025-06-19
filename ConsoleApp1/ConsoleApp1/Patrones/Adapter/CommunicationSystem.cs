using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter
{
    public class CommunicationSystem
    {
        public void StartConversation(ICommunication communication, string q, string a)
        {
            communication.Ask(q);
            communication.Reply(a);
        }
    }
}
