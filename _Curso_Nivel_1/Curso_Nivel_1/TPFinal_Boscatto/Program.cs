namespace TPFinal_Boscatto;
class Program
{
    static void Main(string[] args)
    {
        int numero, contaImpares=0, maxPar=0, primoMenor=0;
        bool banderaDePares=true, verificadordePrimo, banderaDePrimos=true;
        Console.WriteLine("Ingrese un numero");
        numero=int.Parse(Console.ReadLine());
        while (numero!=0)
        {
            if(numero%2!=0)
                contaImpares++;
            else
            {
                if(banderaDePares)
                {
                    maxPar=numero;
                    banderaDePares=false;
                }
                else
                {
                     if (numero>maxPar)
                        maxPar=numero; 
                }
            }
            verificadordePrimo=MenorPrimo(numero);
            if(verificadordePrimo)
            {
                if (banderaDePrimos)
                {
                    primoMenor=numero;
                    banderaDePrimos=false;
                }
                else
                {
                    if(numero<primoMenor)
                    primoMenor=numero;
                }
            }

            Console.WriteLine("Ingrese otro numero o 0 si desea cortar");
            numero=int.Parse(Console.ReadLine());
        }
        if(banderaDePares==true)
        Console.WriteLine("No se ingreso ningun numero par! Por ende no existe un numero par maximo");
        else
        Console.WriteLine("El maximo numero par es: " + maxPar);

        Console.WriteLine("La cantidad de numeros impares ingresados fue: " + contaImpares); 

        if(primoMenor==0)
        Console.WriteLine("No se ingreso ningun numero primo!");
        else
        Console.WriteLine("El menor numero primo ingresado fue el: " + primoMenor);   
    }

    static bool MenorPrimo(int numero)
    {
        int conta=0;
        for (int x = 1; x < numero; x++)
        {
            if(numero%x==0)
            conta++;
        }
        if(conta==1)
        return true;
        else
        return false;
    }
}
