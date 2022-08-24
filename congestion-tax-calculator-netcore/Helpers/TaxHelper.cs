using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using congestion.calculator.Enums;

namespace congestion.calculator.Helpers
{
    public static class TaxHelper
    {
        public static bool IsTollFreeVehicle(IVehicle vehicle)
        {
            if (vehicle == null) return false;
            String vehicleType = vehicle.GetVehicleType();
            return vehicleType.Equals(GetTollFreeVehicle().ToString());
        }

        //Add this data to DB so that each city can have it's own rules about vehicle exumption
        private static Vehicles GetTollFreeVehicle()
        {
            return Vehicles.Motorcycle |
                Vehicles.Buss |
                Vehicles.Emergency |
                Vehicles.Diplomat |
                Vehicles.Foreign |
                Vehicles.Military;
        }
        //Add this data to the DB
        public static int GetTollFee(DateTime date)
        {
            int hour = date.Hour;
            int minute = date.Minute;

            if (hour == 6 && minute >= 0 && minute <= 29) return 8;
            else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
            else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
            else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
            else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
            else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
            else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
            else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
            else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
            else return 0;
        }
    }
}