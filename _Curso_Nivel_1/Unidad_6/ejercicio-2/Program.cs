namespace ejercicio_2;
class Program
{
    static void Main(string[] args)
    {
        bool bandera=false; //bandera del mayor porcentaje
        int numero, numgrup=0, orden=0;
        float mayorporcentaje=0;

        for (int x = 0; x < 5; x++)
        {
            float contador=0, contadorimpar=0, porcentaje;
            float max=0;
            bool bandera2=true;

            Console.WriteLine("ingrese un numero");
            numero=int.Parse(Console.ReadLine());
            while (numero!=0)
            {
                contador++; //Cuento la cantidad de numeros
                if(numero%2!=0) //veo si es impar y cuento
                contadorimpar++;

                if(contador>1) //chequea que desde la segunda vuelta se ingresen numeros ordenados 
                {
                 if (numero>max)
                  bandera2=false;
                  else
                  max=numero;
                }
                else
                max=numero;

            Console.WriteLine("ingrese otro numero");
            numero=int.Parse(Console.ReadLine());
            }
            porcentaje=contadorimpar/contador;
            //calculo el grupo que mas impares tengo, en la primera vuelta salteo el  if y voy al false con la
            //bandera y si se ingreso un impar(promedio>0) se inicializara el primer mayor porcentaje
             
                if(porcentaje>mayorporcentaje)
                {
                mayorporcentaje=porcentaje;
                numgrup=x+1;
                }    
            

            if(bandera2)
            orden++;
        }
        if(numgrup>0)
        Console.WriteLine("El grupo con mayor porcentaje  de impares es el grupo: " + numgrup);
        else
        Console.WriteLine("En ningun grupo se ingreso un numero impar");
        if(orden>0)
        Console.WriteLine("la cantidad de grupos ordenados de Mayor a menor fue: " + orden);
        else
        Console.WriteLine("En ningun grupo se cargo los numeros de forma descendiente");
    }
}
