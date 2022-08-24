using System;
using congestion.calculator.Enums;

namespace congestion.calculator.Models
{
    public class Tractor : IVehicle
    {
        public string GetVehicleType() => Vehicles.Tractor.ToString();
    }
}

