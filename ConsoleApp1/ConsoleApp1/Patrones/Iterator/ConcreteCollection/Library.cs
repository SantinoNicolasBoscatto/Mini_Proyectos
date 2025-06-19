using ConsoleApp1.Patrones.Iterator.Concrete_Iterator;
using ConsoleApp1.Patrones.Iterator.ICollection;
using ConsoleApp1.Patrones.Iterator.IIterator;


namespace ConsoleApp1.Patrones.Iterator.ConcreteCollection
{
    public class Library : IColection<Book>
    {
        private List<Book> _books;
        public Library()
        {
            _books = new List<Book>
            {
                new Book("Pirates of Algibean","Juan"),
                new Book("Pirates of Algibean 2: La venganza del perla","Juan"),
                new Book("En busca por una 33","Nano"),
            };
        }

        public IIterator<Book> CreateIterator()
        {
            return new BookIterator(_books);
        }
    }
}
