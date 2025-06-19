using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Memento.State
{
    public class GameState
    {
        public int Level { get; set; }
        public int Health { get; set; }
        public string? Weapon { get; set; }
    }
}
