using ConsoleApp1.Patrones.Composite.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Composite.Concrete_Class
{
    public class AppFile : IFileSystemItem
    {
        private string _name;
        public AppFile(string name)
        {
            _name = name;
        }

        public void Display(string identacion = "")
        {
            Console.WriteLine($"{identacion}- {this.GetType().Name}: {_name}.jpg");
        }
    }
}
