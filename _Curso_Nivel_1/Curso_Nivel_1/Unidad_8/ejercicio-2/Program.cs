namespace ejercicio_2;
class Program
{
    static void Main(string[] args)
    {
        int contador=0; 
        int numero;
        bool vf;  
        for (int x = 0; x < 20; x++)
        {   
            if (x==0)
            {
              Console.WriteLine("Ingrese el primer numero"); 
               numero= int.Parse(Console.ReadLine());
            }
            else if(x>0 && x<19){
            Console.WriteLine("Ingrese otro numero");
            numero= int.Parse(Console.ReadLine());
            }
            else{
            Console.WriteLine("Ingrese el ultimo numero");
            numero= int.Parse(Console.ReadLine());
            }
            if(par(numero))
            contador++;
        }
        if(contador!=1)
        Console.WriteLine("Hubo " + contador + " Pares");
        else if(contador==1)
        Console.WriteLine("Hubo un Par");
    }

    static bool par(int numero){
        if(numero%2==0)
            return true;
        else
            return false;
    }
}
