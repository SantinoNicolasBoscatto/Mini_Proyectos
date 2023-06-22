namespace Ejercicio_4;
class Program
{
    static void Main(string[] args)
    {  
         float tf, comision, sf;
         const float sueldoFijo = 15000; 
        Console.WriteLine("Ingrese El Total Facturado por el empleado");
        tf=float.Parse(Console.ReadLine());
        comision = tf*0.05f;
        sf = sueldoFijo+comision;
        
        Console.WriteLine("El sueldo total es " + sf);
    }
}
