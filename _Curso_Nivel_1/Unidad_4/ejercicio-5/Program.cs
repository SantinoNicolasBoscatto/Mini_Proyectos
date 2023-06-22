namespace ejercicio_5;
class Program
{
    static void Main(string[] args)
    { 
        float min;
        float[] vnum; 
        vnum = new float[4];

        for(int x=0; x<4; x++)
        {
            if(x==0){
            Console.WriteLine("Ingrese un Numero!");
            vnum[x]=float.Parse(Console.ReadLine());
            }
            else if(x>0 && x<3)
            {Console.WriteLine("Ingrese otro Numero!");
            vnum[x]=float.Parse(Console.ReadLine());}
            else
            {Console.WriteLine("Ingrese el ultimo Numero!");
            vnum[x]=float.Parse(Console.ReadLine());}
        }
        

        if(vnum[0]>vnum[1]&&vnum[1]>vnum[2]&&vnum[2]>vnum[3])
        Console.WriteLine("Esta ordenado de forma decreciente");
        else
        Console.WriteLine("No esta ordenado de forma decreciente");
    }
}
