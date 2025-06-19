using ConsoleApp1.Patrones.Observer._Exercises.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Observer._Exercises.Subject
{
    public interface ISubjectSubasta
    {
        void AddObserver(IObserverSubastas observer);
        void RemoveObserver(IObserverSubastas observer);
        void NotifyObservers(IObserverSubastas observer);
        void PujarSubasta(IObserverSubastas pujador);
    }
}
