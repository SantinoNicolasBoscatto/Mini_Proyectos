using ConsoleApp1.Patrones.Visitor._exercise.Concrete_Element;
using ConsoleApp1.Patrones.Visitor._exercise.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Visitor._exercise.Concrete_Visit
{
    public class Repair : IElectronicOperation
    {
        public void Visit(Laptop pc)
        {
            Console.WriteLine("Reparando Laptop");
        }

        public void Visit(Mobile phone)
        {
            Console.WriteLine("Reparando Mobile");
        }
    }
}
