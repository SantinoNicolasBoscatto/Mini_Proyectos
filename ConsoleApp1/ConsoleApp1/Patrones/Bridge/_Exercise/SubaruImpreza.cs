using ConsoleApp1.Patrones.Bridge._Exercise.Abstraction;
using ConsoleApp1.Patrones.Bridge._Exercise.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Bridge._Exercise
{
    public class SubaruImpreza : VehicleAbstraction
    {
        public SubaruImpreza(IEngine engine) : base(engine)
        {}

        public override void Drive()
        {
            Console.WriteLine("Encendido de impreza");
            _engine.Start();
            Console.WriteLine("Apagado de impreza");
            _engine.Stop();
        }
    }
}
