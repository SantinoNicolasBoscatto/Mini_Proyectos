namespace ejercicio_4;
class Program
{
    static void Main(string[] args)
    {
        int numero, conta=0;
        bool bd=true;
        Console.WriteLine("Ingrese un numero mayor a 1: ");
        while (bd)
        { 
        numero=int.Parse(Console.ReadLine());
        if(numero>1)
        {
        bd=false;
        for (int i = 1; i < numero-1; i++)
        {
        if(numero%i==0)
        conta++;
        }
        if (conta>1)
        Console.WriteLine("No es primo");  
        else
        Console.WriteLine("Es primo");
        }
        else
        Console.Write("Se ingreso un numero menor a 2, ingrese un numero nuevamente y sea mayor a 1: ");
        }
        
    }
}
