using ConsoleApp1.Patrones.Visitor.Element;
using ConsoleApp1.Patrones.Visitor.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Visitor.Concrete_Element
{
    public class Lion : IAnimal
    {
        public void Accept(IAnimalOperation operation)
        {
            operation.VisitLion(this);
        }
    }
}
