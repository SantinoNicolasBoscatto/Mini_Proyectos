using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Builder
{
    // Director
    public class RobotDirector
    {
        // Genero un campo con la interfaz Builder, ya que el director podra aceptar cualquier Builder concreto que  
        // implemente esta Interfaz de builder.
        private IRobotBuilder _robotBuilder;

        public RobotDirector(IRobotBuilder robotBuilder)
        {
            _robotBuilder = robotBuilder;
        }

        public void ConstructRobot()
        {
            _robotBuilder.BuildHead("Cabezon");
            _robotBuilder.BuildBody("Normal");
            _robotBuilder.BuildArms("Claws");
            _robotBuilder.BuildLegs("None");
        }
    }
}
