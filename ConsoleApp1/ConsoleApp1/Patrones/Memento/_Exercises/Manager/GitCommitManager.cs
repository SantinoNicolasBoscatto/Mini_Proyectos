using ConsoleApp1.Patrones.Memento._Exercises.Memento;
using ConsoleApp1.Patrones.Memento._Exercises.Originator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Memento._Exercises.Manager
{
    public class GitCommitManager
    {
        List<GitMemento> _gitMementoList = new List<GitMemento>();

        public void SaveCommit(Repository repo)
        {
            _gitMementoList.Add(repo.SaveState());
        }

        public void RevertCommit(Repository repo, string tree)
        {
            var memento = _gitMementoList.Find(x => x.GitState.Tree == tree);
            if (memento == null) return;
            repo.Restore(memento);
        }
    }
}
