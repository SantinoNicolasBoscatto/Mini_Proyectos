namespace Ejercicio_5;
class Program
{
    static void Main(string[] args)
    {
     float nota1,N2,N3,R;
     Console.WriteLine("Ingrese la Primera nota");
     nota1 = float.Parse(Console.ReadLine());
     Console.WriteLine("Ingrese la segunda nota");
     N2=float.Parse(Console.ReadLine());
     Console.WriteLine("Ingrese la ultima nota");
     N3 = float.Parse(Console.ReadLine());
     R = (nota1 + N2 + N3) / 3;
     Console.WriteLine("El promedio del alumno es: " + R.ToString("0.00"));
    }
}
