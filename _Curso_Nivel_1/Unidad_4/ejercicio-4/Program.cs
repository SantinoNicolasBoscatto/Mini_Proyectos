namespace ejercicio_4;
class Program
{
    static void Main(string[] args)
    {
        float[] vnum;
        vnum = new float[3];
        Console.WriteLine("Hola! Porfavor ingrese 3 numeros!");
        for(int x=0; x<3; x++)
        {
          vnum[x]=float.Parse(Console.ReadLine());
        }
        if(vnum[0]+vnum[1]>vnum[1]*vnum[2])
        Console.WriteLine("La suma de los dos primeros numeros es mayor al producto del segundo con el tercero");
        else
        Console.WriteLine("Viva Peron");
        
        Console.WriteLine("Fin");
    }
}
