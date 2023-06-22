namespace Ejercicio_3;
class Program
{
    static void Main(string[] args)
    {
        float distancia, velocidad;
        float tiempo;
        Console.WriteLine("Introduzca la distancia entre ciudades y la velocidad promedio del Vehiculo!");
        distancia= float.Parse(Console.ReadLine());
        velocidad= float.Parse(Console.ReadLine());
        tiempo = distancia/velocidad;
        if(tiempo%1!=0)
        {
        tiempo = tiempo*60;
        Console.WriteLine("Se tardara " + tiempo.ToString("0") + " minutos");
        }
        else
        {
        Console.WriteLine("Se tardara " + tiempo + " horas");
        }
        
    }
}
