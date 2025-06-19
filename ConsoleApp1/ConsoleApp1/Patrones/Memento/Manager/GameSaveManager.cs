using ConsoleApp1.Patrones.Memento.Memento;
using ConsoleApp1.Patrones.Memento.Originator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Memento.Manager
{
    public class GameSaveManager
    {
        private List<GameMemento> _saves = new List<GameMemento>();

        public void SaveGame(Game game)
        {
            var memento = game.SaveGame();
            _saves.Add(memento);
        }

        public void LoadGame(Game game, int saveSlot)
        {
            game.LoadGame(_saves[saveSlot]);
        }
    }
}
