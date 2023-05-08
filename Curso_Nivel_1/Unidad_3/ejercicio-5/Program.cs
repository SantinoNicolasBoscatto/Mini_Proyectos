namespace ejercicio_5;
class Program
{
    static void Main(string[] args)
    {
        int n1,n2,n3,n4;
        int bandera = 0;
        Console.WriteLine("Ingrese el primer numero");
        n1=int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el segundo numero");
        n2=int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el tercer numero");
        n3=int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el cuarto numero");
        n4=int.Parse(Console.ReadLine());
        if(n1>100)
        {Console.Write(n1+ " ");
        bandera++;}
        
        if(n2>100){
        Console.Write(n2 +" ");
        bandera++;}
        
        if(n3>100){
        Console.Write(n3 + " ");
        bandera++;}
        
        if(n4>100)
        {Console.Write(n4+" ");
        bandera++;} 

        if(bandera>1)
        Console.Write("son numeros son mayores a 100");
        else if (bandera==1)
        Console.Write("es un numero mayor a 100");
        else
        Console.Write("Ningun numero fue mayor a 100");
        }
       
    }

