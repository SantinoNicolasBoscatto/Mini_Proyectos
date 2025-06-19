using ConsoleApp1.Patrones.Visitor._exercise.Concrete_Element;
using ConsoleApp1.Patrones.Visitor._exercise.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Visitor._exercise.Visitor
{
    public interface IElectronicOperation
    {
        void Visit(Laptop pc);
        void Visit(Mobile phone);
    }
}
