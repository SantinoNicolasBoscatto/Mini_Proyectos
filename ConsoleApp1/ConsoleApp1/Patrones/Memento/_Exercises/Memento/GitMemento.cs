using ConsoleApp1.Patrones.Memento._Exercises.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Memento._Exercises.Memento
{
    public class GitMemento
    {
        public GitState GitState { get; private set; }
        public GitMemento(GitState gitState)
        {
            GitState = gitState;
        }
    }
}
