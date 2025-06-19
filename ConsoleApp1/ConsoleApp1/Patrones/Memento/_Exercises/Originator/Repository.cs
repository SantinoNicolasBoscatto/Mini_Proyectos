using ConsoleApp1.Patrones.Memento._Exercises.Memento;
using ConsoleApp1.Patrones.Memento._Exercises.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Memento._Exercises.Originator
{
    public class Repository
    {
        public GitState CurrentState { get; set; } = null!;

        public GitMemento SaveState()
        {
            return new GitMemento(CurrentState);
        }
        public void Restore(GitMemento commit)
        {
            CurrentState = commit.GitState;
        }
    }
}
