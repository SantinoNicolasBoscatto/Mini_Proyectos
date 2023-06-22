namespace ejercicio_3;
class Program
{
    static void Main(string[] args)
    {
        char[] cadenaFuente = new char[501];
        char caracter1; char caracter2;
        int indice=0;

        Console.WriteLine("Ingrese la frase letra por letra");
        cadenaFuente[0]=char.Parse(Console.ReadLine());
       
        while (cadenaFuente[indice]!='.' && indice<500)
        {
            indice++;
            Console.WriteLine("Ingrese la siguiente letra o un punto si desea cortar");
            cadenaFuente[indice]=char.Parse(Console.ReadLine());
               
        }
        cadenaFuente[indice]='\0';

        Console.WriteLine("cargue caracter 1");
        caracter1=char.Parse(Console.ReadLine());
        Console.WriteLine("cargue caracter 2");
        caracter2=char.Parse(Console.ReadLine());
        indice=0;
        while (cadenaFuente[indice]!='\0')
        {
          if(cadenaFuente[indice]==caracter1)
        {
            cadenaFuente[indice]=caracter2;
        }
        indice++;
        }
        
        indice=0;
        Console.Write("La frase nueva es: ");
        while (cadenaFuente[indice]!='\0')
        {
            Console.Write(cadenaFuente[indice]);
            indice++;
        }
    }
}
