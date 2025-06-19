using ConsoleApp1.Patrones.Mediator.Concrete_Class;
using ConsoleApp1.Patrones.Mediator.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Mediator.Concrete_Mediator
{
    public class ECommercePlataform : IMediator
    {
        private ShoppingCart shoppingCart;
        private InventorySystem inventorySystem;
        public ECommercePlataform(ShoppingCart shoppingCart, InventorySystem inventorySystem)
        {
            this.shoppingCart = shoppingCart;
            this.inventorySystem = inventorySystem;
        }

        public void Notify(object sender, string eventCode)
        {
            if(sender is ShoppingCart)
            {
                inventorySystem.CheckItemAvailability(eventCode);
            }
        }
    }
}
