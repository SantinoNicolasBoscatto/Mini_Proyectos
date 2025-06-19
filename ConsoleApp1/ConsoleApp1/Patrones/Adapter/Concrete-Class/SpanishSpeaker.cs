using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter.Concrete_Class
{
    public class SpanishSpeaker
    {
        public void Pregunta(string pregunta)
        {
            Console.WriteLine(pregunta);
        }

        public void Respuesta(string respuesta)
        {
            Console.WriteLine(respuesta);
        }
    }
}
