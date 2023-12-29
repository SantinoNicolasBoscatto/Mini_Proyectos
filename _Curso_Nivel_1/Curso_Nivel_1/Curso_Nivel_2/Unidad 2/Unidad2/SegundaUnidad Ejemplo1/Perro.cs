using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaUnidad_Ejemplo1
{
    class Perro
    {
        int edad;
        string nombre;
        string raza;

        public int Edad
        {
            get { return edad;}
            set { edad = value;}
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Raza
        {
            get { return raza; }
            set { raza = value; }
        }
    }
}
