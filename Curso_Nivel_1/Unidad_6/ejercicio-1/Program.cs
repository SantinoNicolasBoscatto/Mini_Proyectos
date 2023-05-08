 namespace ejercicio_1;
class Program
{
    static void Main(string[] args)
    {  
        int n, cantidad=0;
        for (int x = 0; x < 10; x++)
        {
            int conta=0;
            if (x==0)
            Console.WriteLine("ingrese el primer numero");
            else if(x>0 && x<9)
            Console.WriteLine("ingrese otro numero");
            else
            Console.WriteLine("ingrese el ultimo");
            n= int.Parse(Console.ReadLine());

            for (int y = 1; y < n; y++)
            {
                if(n%y==0)
                conta++;
            }
            if(conta==1)
            cantidad++;
        }
         Console.WriteLine("La cantidad de numeros primos ingresados es: " + cantidad);
    }
}
