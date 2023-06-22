namespace ejercicio_3;
class Program
{
    static void Main(string[] args)
    {
        float edad=0, acu=0, conta=0;
        bool bd=false;
        for (float i = 0; i < 20; i++)
        {
            if (i==0){       
            Console.Write("Hola buenas tardes ingrese una edad!: ");
            }
            if(bd)
            {
            Console.Write("ingrese otra mas: ");  
            }
            else
             bd=true; 

            edad=float.Parse(Console.ReadLine()); 
             if(edad>18)
            {acu+=edad;
            conta++;}     
        }
        acu=acu/conta;
        if(acu>18)
        Console.WriteLine("El promedio de edades mayores a 18 es: " + acu);
        else
        Console.WriteLine("No se ingresaron edades +18");
        
    }
}
