using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Iterator
{
    // El objeto a iterar
    public class Book
    {
        public Book(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }
        public string Titulo { get; set; }
        public string Autor { get; set; }
    }
}
