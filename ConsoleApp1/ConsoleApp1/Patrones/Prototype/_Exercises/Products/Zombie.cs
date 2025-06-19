using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Prototype._Exercises.Products
{
    public class Zombie : Monster
    {
        public int Health { get; set; }
        public Zombie()
        {
            MonsterName = "Vampire";
        }
        public override void Atack()
        {
            Console.WriteLine("Te ataca un " + MonsterName);
        }
    }
}
