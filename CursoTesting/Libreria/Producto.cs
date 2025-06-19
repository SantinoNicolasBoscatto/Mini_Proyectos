using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public double Precio { get; set; }
        public double GetPrecio(ICliente cliente)
        {
            if(cliente.IsPremium)return Precio * .8;
            return Precio;
        }
    }
}
