using System;
using System.Collections.Generic;

namespace congestion_tax_calculator.Models
{
    public class TaxCalculationInput
    {
        public List<DateTime> TollFreeDays { get; set; }
        public MaxInputAmount MaxInputAmount { get; set; }
    }
}

