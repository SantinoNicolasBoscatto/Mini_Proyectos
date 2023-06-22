namespace ejercicio_3;
class Program
{
    static void Main(string[] args)
    {   float importe;

        Console.WriteLine("Ingrese el importe");
        importe=float.Parse(Console.ReadLine());

        if(importe>=5000)
        Console.WriteLine("El Precio final es " + importe*0.82f);
        else if (importe>=1000)
        Console.WriteLine("El Precio final es " + importe*0.9f);
        else    
        Console.WriteLine("El Precio final es " + importe);
    }
}
