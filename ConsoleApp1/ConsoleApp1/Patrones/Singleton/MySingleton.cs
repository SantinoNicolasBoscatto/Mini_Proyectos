using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Singleton
{
    public class MySingleton
    {
        // El campo que se encargara de almacenar la instancia, privado asi no puede ser sobrescrito por fuera.
        // Este campo almacenara la unica instancia de MySingleton
        private static MySingleton _instance = null!;

        // El Constructor debe ser privado asi nos aseguramos que no se pueda instanciar MySingleton directamente.
        private MySingleton()
        {

        }

        // Este metodo se encargara de devolver mi instancia, es el medio de acceso a mi instancia, pero solo para lectura.
        // Ademas valido que si mi instancia no existe, genero una y devuelvo _instance
        public static MySingleton GetInstance()
        {
            if (_instance == null) _instance = new MySingleton();
            return _instance;
        }
    }
}
