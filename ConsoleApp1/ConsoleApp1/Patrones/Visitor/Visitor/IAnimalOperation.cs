using ConsoleApp1.Patrones.Visitor.Concrete_Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Visitor.Visitor
{
    // Esta interfaz va a tener metodos de visita, segun los Concrete-Elements que tengamos
    public interface IAnimalOperation
    {
        void VisitLion(Lion lion);
        void VisitMonkey(Monkey monkey);
    }
}
