using ConsoleApp1.Patrones.Abstract_Factory.Abstracciones;
using ConsoleApp1.Patrones.Abstract_Factory.Concrete_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory.Factorys
{
    public class LinuxFactory : IBaseFactory
    {
        public IButton CreateButton()
        {
            return new LinuxButton();
        }

        public IDropDownList CreateDropDownList()
        {
            throw new NotImplementedException();
        }

        public ITextBox CreateTextBox()
        {
            return new LinuxTextBox();
        }
    }
}
