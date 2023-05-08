namespace ejercicio_4;
class Program
{
    static void Main(string[] args)
    {
        int [] acumuladorventas = new int[15];
        int articuloingreso; int cantidadVendida;
        int max; int numart;
        bool bandera=true;
        
        Console.WriteLine("Ingrese el articulo");
        articuloingreso=int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la cantidad vendida");
        cantidadVendida=int.Parse(Console.ReadLine());
        while(articuloingreso!=0 && articuloingreso<16)
        {
            acumuladorventas[articuloingreso-1]+=cantidadVendida;
            Console.WriteLine("Ingrese otro articulo o 0 si quiere terminar");
            articuloingreso=int.Parse(Console.ReadLine());
            if(articuloingreso!=0)
            {
            Console.WriteLine("Ingrese la cantidad vendida");
            cantidadVendida=int.Parse(Console.ReadLine());
            }
        }

        max=acumuladorventas[0];
        numart=1;
        for (int x = 0; x < 15; x++)
        {
         if(acumuladorventas[x]>max){
            max=acumuladorventas[x];
            numart=x+1;
         }

         if(acumuladorventas[x]==0)
         {
            if(bandera){
            Console.Write("Los articulos que no registraron venta son: " + (x+1));
            bandera=false;
            }         
            else
            Console.Write(" "+(x+1));
         }

        }
        if(bandera==true)
        Console.WriteLine("Todos los articulos registraron ventas!");
        
        Console.WriteLine();
        Console.WriteLine("El articulo que mas vendio fue el articulo nro: " + numart);

        if(acumuladorventas[9]>1)
        Console.WriteLine("El articulo 10 vendio: " + acumuladorventas[9] + " unidades");
        else if(acumuladorventas[9]==1)
        Console.WriteLine("El articulo 10 vendio: una unidad ");
        else
        Console.WriteLine("El articulo 10 no vendio una mierda");
        
    }
}
