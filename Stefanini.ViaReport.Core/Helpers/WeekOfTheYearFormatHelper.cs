using Stefanini.Core.Extensions;
using System;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class WeekOfTheYearFormatHelper : IWeekOfTheYearFormatHelper
    {
        public string Format(DateTime dateTime)
            => $"W{dateTime.GetWeekOfYear()}, {dateTime:yyyy-MM-dd}";
    }
}