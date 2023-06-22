using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDominio
{
    public class Pokemon
    {

        public int Id { get; set; }
        public bool  Activo{ get; set; }
        public string Nombre { get; set; }
        [DisplayName("Numero De Pokedex")]
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
        public Pokemon()
        {
            this.Tipo = new Elemento();
            this.Debilidad = new Elemento();
        }

    }
}
