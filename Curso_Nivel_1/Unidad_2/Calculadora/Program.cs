namespace Calculadora;
class Program
{
    static void Main(string[] args)
    {
        int n1, n2;
        String operador;
        operador=Console.ReadLine();
        
        Console.WriteLine("Ingrese un Numero Porfavor!");
        n1= int.Parse(Console.ReadLine());
        n2= int.Parse(Console.ReadLine());
       int R = n1+n2;
        Console.WriteLine("El Resultado Es: " + R);
        
    }
}
