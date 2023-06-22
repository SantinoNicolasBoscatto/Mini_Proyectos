namespace ejercicio_4;
class Program
{
    static void Main(string[] args)
    {
        int numero, resultado=0;
        Console.WriteLine("Introduzca un numero! se devolvera 1 si es positivo, -1 si es negativo o 0 si es cero");
        numero=int.Parse(Console.ReadLine());
        PNC(numero, ref resultado);
        if(resultado==1)
        Console.WriteLine(resultado+" Usted introdujo un numero positivo");
        if(resultado==0)
        Console.WriteLine(resultado+" Usted introdujo cero");
        if(resultado==-1)
        Console.WriteLine(resultado+" Usted introdujo un numero negativo");
    }

    static void PNC(int numero, ref int resultado)
    {
        if(numero>0)
        resultado=1;
        else if(numero==0)
        resultado=0;
        else
        resultado=-1;
    }
}
