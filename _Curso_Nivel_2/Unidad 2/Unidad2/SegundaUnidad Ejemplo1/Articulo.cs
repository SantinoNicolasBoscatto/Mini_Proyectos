using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaUnidad_Ejemplo1
{
    class Articulo
    {
        private int codigoMarca;

        public float Precio { get; set; }
        public int CodArticulo { get; set; }

        public int CodigoMarca
        {
            get { return codigoMarca;}
            set 
            {
                    if (value > 0 && value < 11)
                        codigoMarca = value;
                    else
                      codigoMarca = -1;
            }
        }



    }
}
