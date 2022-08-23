using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using congestion.calculator;
using congestion.calculator.Enums;
using congestion.calculator.Models;
using congestion_tax_calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace congestion_tax_calculator.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/GetTax")]
        public int GetTax(TaxInput inputData)
        {
            var taxCalcInput = GetTaxCalculationInput(inputData.CityId);

            if (inputData.Vehicle == Vehicles.Tractor)
                return CongestionTaxCalculator.GetTax(new Tractor(), taxCalcInput.MaxInputAmount.Amount, inputData.dates, taxCalcInput.TollFreeDays);
            else if (inputData.Vehicle == Vehicles.Car)
                return CongestionTaxCalculator.GetTax(new Car(), taxCalcInput.MaxInputAmount.Amount, inputData.dates, taxCalcInput.TollFreeDays);
            else
                return 0;
        }

        private TaxCalculationInput GetTaxCalculationInput(int cityId)
        {
            var result = new TaxCalculationInput();

            var cs = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
            using (NpgsqlConnection connection = new NpgsqlConnection(cs))
            {
                var getMaxInputAmount = $"SELECT * FROM maximumamount where cityid = {cityId}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(getMaxInputAmount, connection))
                {
                    connection.Open();
                    var tmp = new MaxInputAmount();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp.Id = reader.GetInt32(0);
                            tmp.Amount = reader.GetInt16(1);
                            tmp.CityId = reader.GetInt32(2);
                        }
                    }
                    result.MaxInputAmount = tmp;
                }

                var tollFreeDays = $"SELECT * FROM tollfreedays where cityid = {cityId}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(tollFreeDays, connection))
                {
                    var tmp = new List<DateTime>();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var date = new TollFreeDays();
                            date.Id = reader.GetInt16(0);
                            date.Date = reader.GetDateTime(1);
                            date.CityId = reader.GetInt16(2);

                            tmp.Add(date.Date);
                        }
                    }
                    result.TollFreeDays = tmp;
                }
            }

            return result;
        }
    }
}

