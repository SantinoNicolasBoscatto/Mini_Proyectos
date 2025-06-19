using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Singleton
{
    public class MySingletonExtend
    {
        private static MySingletonExtend _instance = null!;
        public Guid Id { get; set; }

        private MySingletonExtend()
        {
            Id = Guid.NewGuid();
        }

        public static MySingletonExtend GetInstance()
        {
            if (_instance == null) _instance = new MySingletonExtend();
            return _instance;
        }
    }
}
