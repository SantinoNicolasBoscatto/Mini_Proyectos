using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Template_Method._exercises
{
    public abstract class PastaAbstract
    {
        public abstract void boilWater();
        public abstract void addPasta();
        public abstract void drain();

        public virtual void addSauce() { }
        public virtual void addProtein() { }
        public virtual void addCheese() { }

        public void MakePasta()
        {
            boilWater();
            addPasta();
            drain();
            addSauce();
            addProtein();
            addCheese();
        }
    }
}
