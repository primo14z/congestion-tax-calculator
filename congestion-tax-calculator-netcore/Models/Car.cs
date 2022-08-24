using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using congestion.calculator.Enums;

namespace congestion.calculator
{
    public class Car : IVehicle
    {
        public String GetVehicleType() => Vehicles.Car.ToString();
    }
}