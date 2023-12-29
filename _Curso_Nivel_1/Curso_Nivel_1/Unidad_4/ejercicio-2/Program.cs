namespace ejercicio_2;
class Program
{
    static void Main(string[] args)
    {
        float importe, litros;

        Console.WriteLine("Ingrese el importe de la venta");
        importe=float.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la cantidad de litros vendidos");
        litros=float.Parse(Console.ReadLine());
        if(litros>500)
        importe*= 0.75f;
        else if(litros>= 301)
        importe*=0.85f;
        else if(litros>= 101)
        importe*=0.9f;
        Console.WriteLine("El importe final es: " + importe);
    }
}
