using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Prototype.Products
{
    public class Circle : Shape
    {
        public Circle() 
        {
            Name = "Circle";
        }

        public override void Draw()
        {
            Console.WriteLine("Dibujo Circulo, ID: "+Id);
        }
    }
}
