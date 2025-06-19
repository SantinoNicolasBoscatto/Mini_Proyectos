using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoGrupos.Grupos
{
    public class Grupos
    {
        public Grupos(string name)
        {
            this.Nombre = name;
        }
        public List<Equipos.Equipos> ListaEquipos { get; set; } = new List<Equipos.Equipos>();
        public string Nombre { get; set; }
    }
}
