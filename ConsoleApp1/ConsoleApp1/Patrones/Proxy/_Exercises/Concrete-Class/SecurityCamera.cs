using ConsoleApp1.Patrones.Proxy._Exercises.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Proxy._Exercises.Concrete_Class
{
    public class SecurityCamera : ISecurityCamera
    {
        public void DisplayCamera(int camera)
        {
            Console.WriteLine("Mostrando camara");
        }
    }
}
