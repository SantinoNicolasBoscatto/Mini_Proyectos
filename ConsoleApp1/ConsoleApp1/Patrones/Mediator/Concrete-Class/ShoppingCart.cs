using ConsoleApp1.Patrones.Mediator.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Mediator.Concrete_Class
{
    public class ShoppingCart
    {
        private IMediator _mediator;
        public ShoppingCart(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Esta funcion es auxiliar, porque en el caso de que al construir ShoppingCart debe pasar un Mediator NULL porque 
        // no lo tengo todavia, con este metodo puedo cargarlo cuando lo necesite.
        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Esta funcion sera el disparador de la notificacion
        public void AddItem(string item)
        {
            _mediator.Notify(this, item);
        }
    }
}
