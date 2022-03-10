using System;
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

            var calcBusinessDays = 1 + ((lastDay - firstDay).TotalDays * 5 - (firstDay.DayOfWeek - lastDay.DayOfWeek) * 2) / 7;

            if (lastDay.DayOfWeek == DayOfWeek.Saturday)
                calcBusinessDays--;

            if (firstDay.DayOfWeek == DayOfWeek.Sunday)
                calcBusinessDays--;

            var holidaysPassed = holidays.Count(x => firstDay <= x && x <= lastDay);

            return (decimal)calcBusinessDays - holidaysPassed;
        }
    }
}