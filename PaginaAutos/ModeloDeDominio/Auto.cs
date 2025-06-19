using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDominio
{
    public class Auto
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public int Torque { get; set; }
        public string Traccion { get; set; }
        public int HP { get; set; }
        public int Peso { get; set; }
        public double PesoPotencia { get; set; }
        public double TopSpeed { get; set; }
        public string ImagenMarca { get; set; }
        public string Aspiracion { get; set; }
        public int Precio { get; set; }
        public string Imagen { get; set; }
    }
}
