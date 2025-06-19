using ConsoleApp1.Patrones.Observer._Exercises.Observer;
using ConsoleApp1.Patrones.Observer._Exercises.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Observer._Exercises.Concrete_Subject
{
    public class PlataformaSubastas : ISubjectSubasta
    {
        private List<IObserverSubastas> _observerSubastas = new List<IObserverSubastas>();

        public void AddObserver(IObserverSubastas observer)
        {
            _observerSubastas.Add(observer);
        }
        public void RemoveObserver(IObserverSubastas observer)
        {
            _observerSubastas.Remove(observer);
        }

        public void NotifyObservers(IObserverSubastas observer)
        {
            foreach (var obs in _observerSubastas)
            {
                if(obs == observer) obs.Update(true);
                else obs.Update(false);
            }
        }

        public void PujarSubasta(IObserverSubastas pujador)
        {
            NotifyObservers(pujador);
        }   
    }
}
