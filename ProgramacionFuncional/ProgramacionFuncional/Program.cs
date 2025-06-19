

using BusinessLibrary;
using RepositoryComponent;

var manager = new BeerManager(new BeerRepository(new List<string>()));
manager.Add("null");
Console.WriteLine(manager.Get());