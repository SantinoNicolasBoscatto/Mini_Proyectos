using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaUnidad_Ejemplo1
{
    class Auto
    {
        string nombre;
        int tanqueMax;
        int tanqueAct;

        public Auto() { }
        public Auto(int tanqueMax, int tanqueAct)
        {
            this.tanqueMax = tanqueMax;
            this.tanqueAct = tanqueAct;
        }

        public string Nombre
        {
            get { return nombre;}
            set { nombre = value;}
        }

        public string HolaAE86(string nom)
        {
            if (nom == "AE86")
                return "Hola Especialista del Monte Akina";
                return "Hola " + nom;
        }
        public string HolaAE86()
        {
                return "Hola Santino";
        }

        public string Encendio(bool encendido)
        {
            if (encendido == true)
                return "VROOOOOM";
            else
                return "";

        }

        public int RecargarNafta()
        {
            tanqueAct = 100;
            return 50;
        }

        public int TanqueMax
        {
            get { return tanqueMax; }
        }
    }
}
