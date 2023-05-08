namespace ejercicio_2._1;
class Program
{
    static void Main(string[] args)
    {
        int n=0, mayor=0;
        
        for (int i = 0; i < 10; i++)
        {
            if(i==0){
                Console.WriteLine("Ingrese el primer numero");
                n=int.Parse(Console.ReadLine());
                mayor=n;
            }
            else if(i>0 && i<9){
            Console.WriteLine("Ingrese otro numero");
            n=int.Parse(Console.ReadLine());}
            else{
            Console.WriteLine("Ingrese el ultimo numero"); 
            n=int.Parse(Console.ReadLine());}

            if(n>mayor)
            mayor=n;        
        }
        Console.WriteLine("El numero mayor de los ingresados es: " + mayor);
        
    }
}
