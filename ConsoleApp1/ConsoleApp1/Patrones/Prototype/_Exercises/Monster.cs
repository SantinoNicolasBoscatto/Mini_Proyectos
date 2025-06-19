using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Prototype._Exercises
{
    public abstract class Monster : IClonable
    {
        public int Id { get; set; }
        public string MonsterName { get; set; } = null!;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public abstract void Atack();
    }
}
