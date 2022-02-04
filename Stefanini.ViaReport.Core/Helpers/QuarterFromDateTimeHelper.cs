using System;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class QuarterFromDateTimeHelper : IQuarterFromDateTimeHelper
    {
        public string GetQuarter(DateTime date)
            => date.Month switch
            {
                1 or 2 or 3 => $"Q1{date.Year}",
                4 or 5 or 6 => $"Q2{date.Year}",
                7 or 8 or 9 => $"Q3{date.Year}",
                10 or 11 or 12 => $"Q4{date.Year}",
                _ => throw new ArgumentException(),
            };
    }
}