using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaUnidad_Ejemplo1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool encender;
            int numero;
            Auto auto = new Auto(100, 0);
            auto.Nombre = Console.ReadLine();
            Console.WriteLine(auto.HolaAE86(auto.Nombre));
            Console.WriteLine("Quiere encender el auto? 1 Si, 0 No");
            numero = int.Parse(Console.ReadLine());
            if (numero == 1) 
                encender = true;
            else
                encender = false;
            Console.WriteLine(auto.Encendio(encender));
            Console.WriteLine("El costo de cargar el auto fue de "+auto.RecargarNafta()+ " Pesos");
                Console.ReadKey();

        }
    }
}
