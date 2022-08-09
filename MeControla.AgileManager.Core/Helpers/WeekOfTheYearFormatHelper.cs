using MeControla.Kernel.Extensions;
using System;

namespace MeControla.AgileManager.Core.Helpers
{
    public class WeekOfTheYearFormatHelper : IWeekOfTheYearFormatHelper
    {
        public string Format(DateTime dateTime)
            => $"W{dateTime.GetWeekOfYear()}, {dateTime:yyyy-MM-dd}";
    }
}