using ConsoleApp1.Patrones.Adapter.Concrete_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Adapter
{
    public class Translator : ICommunication
    {
        private readonly SpanishSpeaker spanishSpeaker;

        public Translator(SpanishSpeaker spanishSpeaker)
        {
            this.spanishSpeaker = spanishSpeaker;
        }
        public void Ask(string question)
        {
            spanishSpeaker.Pregunta(question);
        }
        public void Reply(string answer)
        {
            spanishSpeaker.Respuesta(answer);
        }
    }
}
