using ConsoleApp1.Patrones.Visitor.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Visitor.Element
{
    public interface IAnimal
    {
        // Cada animal debo poder aceptar una Operation, que seran las acciones que ejecutaran, segun las 
        // defina en el Concrete-Visitor. De esta forma definimos dinamicamente las operaciones que realizara 
        // un animal.
        void Accept(IAnimalOperation operation);
    }
}
