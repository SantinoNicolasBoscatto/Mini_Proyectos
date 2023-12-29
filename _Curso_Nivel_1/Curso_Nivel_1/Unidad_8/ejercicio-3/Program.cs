namespace ejercicio_3;
class Program
{
    static void Main(string[] args)
    {
        float numero, resultado=0, contador=0, acumulador=0, promedio=0; 

        Console.WriteLine("Ingrese el primer numero");
        numero= float.Parse(Console.ReadLine());
        mientras(numero, resultado, ref contador, ref acumulador);
        if(contador>0)
        Console.WriteLine("El promedio del valor de los numeros primos ingresados es: " + (promedio=acumulador/contador)); 
        else
        Console.WriteLine("No se ingresaron numeros primos papus :`v");
    }
    static int primo(float numero){
        float contador=0;
        for (float x = 1; x < numero; x++)
        {
            if (numero%x==0)
            contador++;
        }
        if (contador==1)
        return 1;
        else
        return 0;
    }
    static void mientras(float numero, float resultado, ref float contador, ref float acumulador)
    {
        while (numero!=0)
        {
            resultado=primo(numero);
            if(resultado==1)
            {
                contador++;
                acumulador+=numero;  
            }
            Console.WriteLine("Ingrese otro numero o 0 para cortar");
            numero= float.Parse(Console.ReadLine());
        }
    }
}
