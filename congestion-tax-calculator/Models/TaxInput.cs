using System;
using congestion.calculator;
using congestion.calculator.Enums;

namespace congestion_tax_calculator.Models
{
    public class TaxInput
    {
        public Vehicles Vehicle { get; set; }
        public DateTime[] dates { get; set; }
        public int CityId { get;set; }
    }
}

