using ConsoleApp1.Patrones.Iterator.IIterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Iterator.Concrete_Iterator
{
    public class BookIterator : IIterator<Book>
    {
        private int position = 0;
        private List<Book> books;
        public BookIterator(List<Book> books)
        {
            this.books = books;
        }

        public bool HasNext()
        {
            return position < books.Count;
        }

        public Book Next()
        {
            var book = books[position];
            position++;
            return book;
        }
    }
}
