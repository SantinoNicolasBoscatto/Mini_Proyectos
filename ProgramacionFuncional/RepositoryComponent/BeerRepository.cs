using BusinessLibrary;

namespace RepositoryComponent
{
    public class BeerRepository : IRepository
    {
        private List<string> _list;
        public BeerRepository(List<string> list)
        {
            _list = list;
        }

        public void Add(string beer) => _list.Add(beer);

        // Aggregate me ahorra el foreach
        public string Get() => _list.Aggregate("", (acumulado, elementoActual) => acumulado + elementoActual + ", ");
    }
}
