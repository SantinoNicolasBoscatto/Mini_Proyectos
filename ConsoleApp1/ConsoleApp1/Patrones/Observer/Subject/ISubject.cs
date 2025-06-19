using ConsoleApp1.Patrones.Observer.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Observer.Subject
{
    public interface ISubject
    {
        // Todo elemento que quiera ser observado debe tener la capacidad de registrar y borrar un observador.
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);

        // Este metodo es la base del patron observer, es el que notificara los cambios del observado a los 
        // Observadores.
        void NotifyObservers();
    }
}
