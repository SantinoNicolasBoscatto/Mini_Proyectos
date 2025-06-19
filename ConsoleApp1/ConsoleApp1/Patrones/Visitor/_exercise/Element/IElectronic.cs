using ConsoleApp1.Patrones.Visitor._exercise.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Visitor._exercise.Element
{
    public interface IElectronic
    {
        void Accept(IElectronicOperation operation);
    }
}
