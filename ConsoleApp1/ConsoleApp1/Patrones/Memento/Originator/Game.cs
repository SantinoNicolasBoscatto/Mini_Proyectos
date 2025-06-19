using ConsoleApp1.Patrones.Memento.Memento;
using ConsoleApp1.Patrones.Memento.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Memento.Originator
{
    public class Game
    {
        // Aca actualizaremos el estado actual.
        public GameState? CurrentState { get; set; }

        public GameMemento SaveGame()
        {
            return new GameMemento(CurrentState!);
        }

        public void LoadGame(GameMemento gameMemento)
        {
            CurrentState = gameMemento.State;
        }
    }
}
