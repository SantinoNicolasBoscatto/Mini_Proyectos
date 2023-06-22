namespace ejercicio_4;
class Program
{
    static void Main(string[] args)
    {
        int n1,n2,n3,n4, min;
        Console.WriteLine("Ingrese el primer numero, no se pueden repetir numeros en el ingreso!");
        n1=int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el segundo numero");
        n2=int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el tercer numero");
        n3=int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el cuarto numero");
        n4=int.Parse(Console.ReadLine());
        if(n1<n2)
            min=n1;
        else
        min=n2;
        if(n3<min)
        min=n3;
        if(n4<min)
        min=n4;
        Console.WriteLine("El menor numero de los ingresados es " + min);
    }
}
