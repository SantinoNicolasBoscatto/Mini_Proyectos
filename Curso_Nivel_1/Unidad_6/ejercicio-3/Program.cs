namespace ejercicio_3;
class Program
{
    static void Main(string[] args)
    {
        int numero, conta=0;

        do 
        {
        int conta2numeros=0;
        conta++;
        Console.WriteLine("Ingrese el primer numero del sublote " + conta);
        numero=int.Parse(Console.ReadLine());

        while(numero>0)
        {
        conta2numeros++;
        Console.WriteLine("Ingrese otro numero del sublote: " + conta);
        numero=int.Parse(Console.ReadLine());
        }

        if(conta2numeros>1)
        Console.WriteLine("El lote nro " + conta + " tiene " + conta2numeros +" numeros ingresados");
        else if(conta2numeros==1)
        Console.WriteLine("El lote nro " + conta + " tiene un numero ingresado");
        else
        Console.WriteLine("En el lote nro " + conta + " no se ingreso ningun numero");
        }while(numero>=0);
        
    }
}
