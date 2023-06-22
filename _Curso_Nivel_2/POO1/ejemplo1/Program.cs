using System;

namespace ejemplo1
{
    class Program
    {
        static void Main(string[] args)
        {
            int e, edades;
            Persona p1 = new Persona();
            e = int.Parse(Console.ReadLine());
            p1.setEdad(e);
            edades = p1.getEdad();
            Console.WriteLine(edades);
        }
    }

}
