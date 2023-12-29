namespace ejercicio_1;
class Program
{
    static void Main(string[] args)
    {
        float cantidadven, precio, resultado;
        Console.WriteLine("Ingrese la cantidad vendida del articulo");
        cantidadven= float.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el precio unitario del articulo");
        precio=float.Parse(Console.ReadLine());
        resultado= producto(cantidadven, precio);
        Console.WriteLine("El monto final a pagar es: " + resultado);
    }

    static float producto(float cantidadven, float precio){
        float resultado;
        resultado = cantidadven*precio;
        return resultado;
    }
}
