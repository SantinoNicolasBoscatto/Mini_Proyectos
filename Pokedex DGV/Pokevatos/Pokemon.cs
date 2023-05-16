using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokevatos
{
    class Pokemon
    {
        public string Nombre { get; set; }
        public int NumeroPokedex { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public Elemento Tipo { get; set; }
        public Elemento Debilidad { get; set; }
        public Pokemon(string type, string weakness)
        {
            this.Tipo = new Elemento();
            this.Tipo.Descripcion = type;
            this.Debilidad = new Elemento();
            this.Debilidad.Descripcion = weakness;
        }
            
    }
}
