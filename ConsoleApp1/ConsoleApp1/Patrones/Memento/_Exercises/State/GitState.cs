using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Memento._Exercises.State
{
    public class GitState
    {
        public string Tree { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
