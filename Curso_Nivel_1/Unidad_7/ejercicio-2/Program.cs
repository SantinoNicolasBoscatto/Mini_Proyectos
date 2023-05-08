namespace ejercicio_2;
class Program
{
    static void Main(string[] args)
    {
        
        int[] numeros = new int[10];
        float acu=0;
        float resultado;
        bool bandera=true;

        Console.WriteLine("Ingrese 10 numeros");
        for (int x = 0; x < 10; x++)
        {
            numeros[x]=int.Parse(Console.ReadLine());
            acu+=numeros[x];
        }
        resultado= acu/10;
        Console.WriteLine("El promedio de los numeros ingresados es: " + resultado);
        for (int x = 0; x < 10; x++)
        {
            if (numeros[x]>resultado)
            {
                if(bandera){ 
                Console.Write("Los numeros mayores al promedio son: " + numeros[x]);
                bandera=false;
                }
                else
                Console.Write(", " + numeros[x]);
            }
        }
        if (bandera==true)
        {
            Console.Write("No hubo numeros mayores al promedio");
        }
    }
}
