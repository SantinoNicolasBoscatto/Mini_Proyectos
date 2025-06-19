using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Singleton
{
    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe? _instance;
        private static readonly object _lock = new object();
        private SingletonThreadSafe()
        {}

        public static SingletonThreadSafe GetInstance()
        {
            if (_instance == null)
            {
                // La palabra clave lock me permitira al trabajar con Multi-hilos hacer entrar a esta condicion un 
                // Hilo a la vez, porque sino podrian entrar varios hilos a la vez y generar multiples instancias de un 
                // singleton.
                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new SingletonThreadSafe();
                    }
                }
            }
            return _instance;
        }
    }
}
