using ConsoleApp1.Patrones.Abstract_Factory.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory.Concrete_Class
{
    // Crearemos las clases concretas que implementaran las abstracciones (IButton, ITextBox)
    public class LinuxButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Me renderizo Linux");
        }
    }
    public class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Me renderizo Mac");
        }
    }
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Me renderizo Win");
        }
    }
}
