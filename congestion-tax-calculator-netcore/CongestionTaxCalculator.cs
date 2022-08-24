using System;
using System.Collections.Generic;
using System.Linq;
using congestion.calculator;
using congestion.calculator.Helpers;

public static class CongestionTaxCalculator
{
    /**
        * Calculate the total toll fee for one day
        *
        * @param vehicle - the vehicle
        * @param dates   - date and time of all passes on one day
        * @return - the total congestion tax for that day
    */
    public static int GetTax(IVehicle vehicle, int maxAmount, DateTime[] dates, List<DateTime> tollFreeDays)
    {
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        if (!TaxHelper.IsTollFreeVehicle(vehicle))
        {
            foreach (DateTime date in dates)
            {
                if (tollFreeDays.Any(x => x == date) ||
                    date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return 0;

                int nextFee = TaxHelper.GetTollFee(date);
                int tempFee = TaxHelper.GetTollFee(intervalStart);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            if (totalFee > maxAmount) totalFee = maxAmount;
            return totalFee;
        }
        else
        {
            return 0;
        }
    }
}