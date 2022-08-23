using System;
namespace congestion_tax_calculator.Models
{
    public class TollFreeDays
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CityId { get; set; }
    }
}

