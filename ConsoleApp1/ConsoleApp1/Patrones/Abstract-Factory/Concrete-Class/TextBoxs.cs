using ConsoleApp1.Patrones.Abstract_Factory.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory.Concrete_Class
{
    public class LinuxTextBox : ITextBox
    {
        public void Render()
        {
            throw new NotImplementedException();
        }
    }
    public class WindowsTextBox : ITextBox
    {
        public void Render()
        {
            throw new NotImplementedException();
        }
    }
    public class MacTextBox : ITextBox
    {
        public void Render()
        {
            throw new NotImplementedException();
        }
    }
}
