using ConsoleApp1.Patrones.Visitor.Concrete_Element;
using ConsoleApp1.Patrones.Visitor.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Visitor.Concrete_Visitor
{
    public class MedicalCheck : IAnimalOperation
    {
        public void VisitLion(Lion lion)
        {
            Console.WriteLine("Revisando medicamente al leon");
        }

        public void VisitMonkey(Monkey monkey)
        {
            Console.WriteLine("Revisando medicamente al mono");
        }
    }
}
