using ConsoleApp1.Patrones.Factory_Method.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Factory_Method
{
    public static class FactoryService
    {
        public static IVehicle Execute(IVehicleFactory vehicleFactory)
        {
            return vehicleFactory.CreateVehicle();
        }
    }
}
