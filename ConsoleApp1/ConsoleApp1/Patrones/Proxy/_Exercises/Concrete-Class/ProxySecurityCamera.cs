using ConsoleApp1.Patrones.Proxy._Exercises.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Proxy._Exercises.Concrete_Class
{
    public class ProxySecurityCamera : ISecurityCamera
    {
        private string _user;
        private SecurityCamera _securityCamera;
        public ProxySecurityCamera(SecurityCamera securityCamera, string user)
        {
            _securityCamera = securityCamera;
            _user = user;
        }

        public void DisplayCamera(int camera)
        {
            if (camera == (int)CameraNumbers.Habitacion && _user != "Admin")
            {
                Console.WriteLine("Esta camara solo es accesible por el administrador");
            }
            else if (camera > (int)CameraNumbers.Habitacion)
            {
                Console.WriteLine("Esta camara no existe");
            }
            else
            {
                _securityCamera.DisplayCamera(camera);
            }
        }
    }
}
