using System;

namespace Primer_Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            float a,b,r;
            string signo;
            Console.WriteLine("Ingrese el primer numero");
            a= float.Parse(Console.ReadLine());
            Console.WriteLine("Operador matematico/Signo");
            signo=Console.ReadLine();
            Console.WriteLine("Ingrese el segundo numero");
            b= float.Parse(Console.ReadLine());

            switch (signo)
            {
                case "+":
                r= a+b;
                Console.WriteLine(r);
                break;
                case "-":
                r= a-b;
                Console.WriteLine(r);
                break;
                case "/":
                r= a/b;
                Console.WriteLine(r);
                break;
                case "*":
                r= a*b;
                Console.WriteLine(r);
                break;
                default:
                Console.WriteLine("Error");
                break;

                
            }
        }
    }
}
