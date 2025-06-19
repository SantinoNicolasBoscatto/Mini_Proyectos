using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Template_Method.Concrete_Class
{
    public class Bank : HiringProcess
    {
        public override void ConductInterview()
        {
            Console.WriteLine("Entrevistando");
        }

        public override void IssueOffer()
        {
            Console.WriteLine("Contratado");
        }

        public override void ReceiveCV()
        {
            Console.WriteLine("Recibiendo CV");
        }
    }
}
