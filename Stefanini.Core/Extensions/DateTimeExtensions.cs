using System;
using System.Diagnostics;
using System.Globalization;

namespace Stefanini.Core.Extensions
{
    public static class DateTimeExtensions
    {
        [DebuggerStepThrough]
        public static int GetWeekOfYear(this DateTime value)
            => CultureInfo.CurrentCulture
                          .Calendar
                          .GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }
}