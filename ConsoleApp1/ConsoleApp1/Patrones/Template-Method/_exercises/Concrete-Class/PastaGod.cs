using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Template_Method._exercises.Concrete_Class
{
    public class PastaGod : PastaAbstract
    {
        public override void addPasta()
        {
            Console.WriteLine("Agrego pasta");
        }

        public override void boilWater()
        {
            Console.WriteLine("Agrego Agua caliente");
        }

        public override void drain()
        {
            Console.WriteLine("Colo pastas");
        }

        public override void addCheese()
        {
            Console.WriteLine("Agrego queso");
        }

        public override void addProtein()
        {
            Console.WriteLine("Agrego prote");
        }

        public override void addSauce()
        {
            Console.WriteLine("Agrego Salsa");
        }
    }
}
