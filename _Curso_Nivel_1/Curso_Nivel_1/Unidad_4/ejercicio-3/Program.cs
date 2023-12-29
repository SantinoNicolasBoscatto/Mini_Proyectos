namespace ejercicio_3;
class Program
{
    static void Main(string[] args)
    {
        int contador=0;
        bool v=false;
        bool verificador=true;
        float montoFinal=0;
        int micro, ram=0, disco;
        string nombreCPU="", nombreRAM;
       bool bandera =false;
       
        Console.Write("Hola! Porfavor elija un microprocesador! I5=1 I7=2 I9=3: ");
        micro=int.Parse(Console.ReadLine());
        while(verificador==true)
        switch(micro)
        {          
            case 1:
            nombreCPU="I5";
            do {
                if(contador==0){
                Console.Write("Porfavor elija su memoria RAM! 8GB=1 16GB=2 32GB=3: ");
                ram=int.Parse(Console.ReadLine());
                contador++;
                }
                else{
                Console.Write("Eleccion Invalida, Vuelva a introducir la opcion de memoria RAM que desea!: ");
                ram=int.Parse(Console.ReadLine());
                }

                switch(ram)
            {               
                case 1:
                montoFinal+=800; 
                v=true;
                break;
                case 2:montoFinal+=900;
                v=true;
                break;
                case 3:montoFinal+=1000;
                v=true;
                break;
                default: 
                v=false;
                break;
            }    
            }
            while(v==false);
            verificador=false;
            break;

            case 2:
            nombreCPU="I7";
            do {
                if(contador==0){
                Console.Write("Porfavor elija su memoria RAM! 8GB=1 16GB=2 32GB=3: ");
                ram=int.Parse(Console.ReadLine());
                contador++;
                }
                else{
                Console.Write("Eleccion Invalida, Vuelva a introducir la opcion de memoria RAM que desea!: ");
                ram=int.Parse(Console.ReadLine());
                }
            switch(ram)
            {
                case 1:montoFinal+=900;
                v=true;
                break;
                
                case 2:montoFinal+=1000;
                v=true;
                break;

                case 3:montoFinal+=1400;  
                v=true;           
                break;

                default:
                v=false;
                break;
            }
            }while(v==false);
            verificador=false;
            break;

            case 3:
            nombreCPU="I9";
            do {
                if(contador==0){
                Console.Write("Porfavor elija su memoria RAM! 8GB=1 16GB=2 32GB=3: ");
                ram=int.Parse(Console.ReadLine());
                contador++;
                }
                else{
                Console.Write("Eleccion Invalida, Vuelva a introducir la opcion de memoria RAM que desea!: ");
                ram=int.Parse(Console.ReadLine());
                }
            switch(ram)
            {
                case 1:montoFinal+=1200;
                v=true;               
                break;

                case 2:montoFinal+=1400;
                v=true;
                break;

                case 3: montoFinal+=2000;
                v=true;   
                break;

                default:
                //v=false;
                break;

            } 
            }while(v==false);
            verificador=false;
            break;
            
            default: Console.Write("Eleccion Invalida, Vuelva a introducir la opcion del micro que desea!: ");
            micro=int.Parse(Console.ReadLine());
            verificador=true;
            break;
         }     
           if(ram==1)
           nombreRAM="8GB";
           else if (ram==2)
           nombreRAM="16GB";
           else
           nombreRAM="32GB";
           Console.Write("Quiere Extender su disco ssd a 1tb? Presione 1 si quiere, 0 sino: ");
           while(bandera == false){
            disco= int.Parse(Console.ReadLine());
            if(disco==1){
           montoFinal+=300;
           bandera=true;
            }
           else if(disco==0)
           bandera=true;
           else
           Console.WriteLine("No se ingreso opcion valida, porfavor elija una opcion valida!");
           }
           Console.WriteLine("Sus opciones elegidas fueron un procesador " + nombreCPU + " y una ram de " + nombreRAM);
           Console.WriteLine("Su monto total a abonar sera de: " + montoFinal + "USD");
    }
}
