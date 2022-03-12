using System;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class BusinessDayHelper : IBusinessDayHelper
    {
        private const string ARGUMENT_LAST_BIG_FIRST = "Incorrect last day";

        public decimal Diff(DateTime firstDay, DateTime lastDay)
            => Diff(firstDay, lastDay, Array.Empty<DateTime>());

        public decimal Diff(DateTime firstDay, DateTime lastDay, DateTime[] holidays)
        {
            if (firstDay > lastDay)
                throw new ArgumentException($"{ARGUMENT_LAST_BIG_FIRST} {lastDay}");

            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            if (firstDay > lastDay)
                throw new ArgumentException($"{ARGUMENT_LAST_BIG_FIRST} {lastDay}");
            
            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            // find out if there are weekends during the time exceedng the full weeks
            if (businessDays > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = (int)firstDay.DayOfWeek;
                int lastDayOfWeek = (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                    businessDays -= 1;
            }
            
            // subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount + fullWeekCount;
            
            // subtract the number of bank holidays during the time interval
            foreach (DateTime bankHoliday in holidays)
            {
                DateTime bh = bankHoliday.Date;
                if (firstDay <= bh && bh <= lastDay)
                    --businessDays;
            }
            
            return businessDays -1 ;
        }
    }
}