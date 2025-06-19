using ConsoleApp1.Patrones.Composite.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Composite.Concrete_Class
{
    public class Folder : IFileSystemItem
    {
        private string _name;
        // Al poder tener archivos y carpetas dentro suyo le creamos que campo que almacene estos
        private List<IFileSystemItem> _items;
        public Folder(string name)
        {
            _name = name;
            _items = new List<IFileSystemItem>();
        }

        public void Display(string identacion = "")
        {
            Console.WriteLine($"{identacion}- {this.GetType().Name}: {_name}.jpg");
            foreach (IFileSystemItem item in _items)
            {
                item.Display(identacion + "  ");
            }
        }

        public void AddItem(IFileSystemItem item)
        {
            _items.Add(item);
        }
    }
}
