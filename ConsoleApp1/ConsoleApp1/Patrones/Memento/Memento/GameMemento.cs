using ConsoleApp1.Patrones.Memento.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Memento.Memento
{
    // En todas las implementaciones no es necesario tener a Memento y a State, con una basta, pero tener ambas me permite
    // ocultar informacion, es decir el Caretaker no conocera que atributos maneja State, solo le interesa que sea un 
    // Memento
    public class GameMemento
    {
        public GameState State { get; private set; }
        public GameMemento(GameState state)
        {
            State = state;
        }
    }
}
