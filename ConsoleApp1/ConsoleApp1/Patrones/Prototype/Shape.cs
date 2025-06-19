using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Prototype
{
    // Clase Concreta que implementa IClonable, Concrete-Prototype
    public abstract class Shape : IClonable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public object Clone()
        {
            // Este metodo me permite crear una copia del objeto sobre el que estoy parado y retornarlo
            return this.MemberwiseClone();
        }
        // Defino un metodo abstracto que despues debere implementar en las clases hijas
        public abstract void Draw();
    }
}
