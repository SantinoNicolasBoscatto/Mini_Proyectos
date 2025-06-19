using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Iterator._Exercises.IIterator
{
    public interface IFacebookIterator<T>
    {
        T Next();
        bool HasNext();
    }
}
