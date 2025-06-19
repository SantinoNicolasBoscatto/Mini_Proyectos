using ConsoleApp1.Patrones.Mediator.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Mediator.Concrete_Class
{
    public class InventorySystem
    {
        private IMediator _mediator;
        public InventorySystem(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Si tuviera una funcion que se ejecute al tener mas items fisicos ahi si llamariamos al mediator, en este caso 
        // no es necesario.
        public void CheckItemAvailability(string item)
        {
            Console.WriteLine("Checkeando " + item);
        }
    }
}
