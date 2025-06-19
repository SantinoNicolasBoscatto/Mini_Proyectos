using ConsoleApp1.Patrones.Visitor._exercise.Element;
using ConsoleApp1.Patrones.Visitor._exercise.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Visitor._exercise.Concrete_Element
{
    public class Mobile : IElectronic
    {
        public void Accept(IElectronicOperation operation)
        {
           operation.Visit(this);
        }
    }
}
