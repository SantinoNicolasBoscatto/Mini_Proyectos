using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Domain
{
    public class Concept
    {
        public int IdBeer { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }
        public decimal Price { get; }

        public Concept(int idBeer, int quantity, decimal unitPrice)
        {
            IdBeer = idBeer;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Price = Quantity * UnitPrice;
        }    
    }
}
