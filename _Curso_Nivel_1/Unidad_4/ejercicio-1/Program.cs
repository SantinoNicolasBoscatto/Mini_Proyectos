namespace ejercicio_1;
class Program
{
    static void Main(string[] args)
    {
        string operacion;
        int a,b,r;
        Console.Write("Ingrese el primer numero: ");
        a=int.Parse(Console.ReadLine());
        Console.Write("Ingrese el segundo numero: ");
        b= int.Parse(Console.ReadLine());

        if (a>b)
         {r=a-b;
         operacion="Se realizo una resta";}
        else if(a==b){
        r=a+b;
        operacion="Se realizo una suma";}
        else
        {r=a*b;
        operacion="Se realizo una multiplicacion";
        }

        Console.WriteLine(operacion + ". " + "El resultado es: " + r);
    }
}
