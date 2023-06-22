namespace ejercicio_1;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese 10 numeros");
        int[] numeros = new int[10];
        int max=0, posicion=0;

        for (int x = 0; x < 10; x++)
        {
            numeros[x] = int.Parse(Console.ReadLine());

            if(x>0 && numeros[x]>max)
            {
                max=numeros[x];
                posicion=x+1;
                
            }
            else if (x==0)
            {
                max=numeros[0];
                posicion=1;
            }
        }
        Console.WriteLine("El mayor numero ingresado es: " + max + " Y su posicion de ingreso fue: " + posicion);
    }
}
