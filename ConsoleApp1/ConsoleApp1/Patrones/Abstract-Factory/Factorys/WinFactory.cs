using ConsoleApp1.Patrones.Abstract_Factory.Abstracciones;
using ConsoleApp1.Patrones.Abstract_Factory.Concrete_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory.Factorys
{
    public class WinFactory : IBaseFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ITextBox CreateTextBox()
        {
            return new WindowsTextBox();
        }

        public IDropDownList CreateDropDownList()
        {
            throw new NotImplementedException();
        }
    }
}
