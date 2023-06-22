namespace ejercicio_1;
class Program
{
    static void Main(string[] args)
    {
        int n1;
        Console.WriteLine("Ingrese un numero");
        n1=int.Parse(Console.ReadLine());
        if(n1>10)
        Console.WriteLine("El numero ingresado es mayor a 10");
        else
        Console.WriteLine("El numero ingresado no es mayor a 10");
    }
}
