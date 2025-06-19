using ConsoleApp1.Patrones.Iterator.IIterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Iterator.ICollection
{
    public interface IColection<T>
    {
        IIterator<T> CreateIterator();
    }
}
