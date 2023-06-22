namespace ejercicio_5;
class Program
{
    static void Main(string[] args)
    {
        int n, max=0, min=0, contapar=0, contaimpar=0;
        bool bandera=false, bandera2=false;
        for (int i = 0; i < 20; i++)
        {
            if (i==0)
            {
             Console.WriteLine("Ingrese el primer numero: ");
             n= int.Parse(Console.ReadLine());   
            }
            else if (i>0 && i<19)
            {
             Console.WriteLine("Ingrese otro numero: ");
             n= int.Parse(Console.ReadLine());   
            }
            else
            {
            Console.WriteLine("Ingrese el ultimo numero: ");
            n= int.Parse(Console.ReadLine()); 
            }
            if(n%2==0)
            {
             if(bandera)
             {
              if (n>max) 
                max=n;
             }
             else
             {max=n;
              bandera=true;
              contapar++;
             }
            }
            else
            {
               if(bandera2)
             {
              if (n<min)
              {
                min=n;
              }
             }
             else
             {min=n;
              bandera2=true;
              contaimpar++;
             } 
            }
        }
        if(contaimpar==1 && contapar==1)
        Console.WriteLine("El mayor de los pares es " + max+" y el menor de los impares es: " + min);
        else if(contaimpar==1 && contapar==0)
        Console.WriteLine("El menor de los impares es: " + min + ". No se ingresaron numeros pares");
        else
        Console.WriteLine("El mayor de los pares es: " + max + ". No se ingresaron numeros impares");
    }
}
