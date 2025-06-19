using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Builder
{
    // Concrete Builder
    public class RobotBuilder : IRobotBuilder
    {
        // Creo un campo con una instancia del objeto a construir, luego en los metodos de la interfaz me encargare de 
        // de llenar de data este objeto.
        private Robot _robot = new Robot();

        public void BuildArms(string arms)
        {
            _robot.Arms = arms;
        }
        public void BuildBody(string body)
        {
            _robot.Body = body;
        }
        public void BuildHead(string head)
        {
            _robot.Head = head;
        }
        public void BuildLegs(string legs)
        {
            _robot.Legs = legs;
        }

        public Robot GetRobot()
        {
            return _robot;
        }
    }
}
 