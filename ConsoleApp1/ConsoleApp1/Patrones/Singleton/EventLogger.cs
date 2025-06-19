using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Singleton
{
    public class EventLogger
    {
        // Campo que guardara la unica instancia de la clase, guardara el singleton
        private static EventLogger? _instance;
        // Una lista donde guardaremos Logs
        private List<string>? _eventsLogs;

        // Constructor privado para no poder instanciar la clase por fuera, ahi mismo inicializo la lista
        private EventLogger() 
        {
            _eventsLogs = new List<string>();
        }

        // Funcion para obtener la instancia
        public static EventLogger GetInstance()
        {
            if (_instance == null) _instance = new EventLogger();
            return _instance;
        }

        // Funcion para guardar Logs
        public void LogEvent(string msgEvent)
        {
            string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            _eventsLogs!.Add($"{timeStamp}: {msgEvent}");
        }

        // Funcion para mostrar Logs
        public void DisplayLogs()
        {
            foreach (var item in _eventsLogs!)
            {
                Console.WriteLine(item);
            }
        }
    }
}
