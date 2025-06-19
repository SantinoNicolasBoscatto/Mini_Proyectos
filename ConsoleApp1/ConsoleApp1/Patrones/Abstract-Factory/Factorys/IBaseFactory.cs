using ConsoleApp1.Patrones.Abstract_Factory.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory.Factorys
{
    public interface IBaseFactory
    {
        IButton CreateButton();
        IDropDownList CreateDropDownList();
        ITextBox CreateTextBox();
    }
}
