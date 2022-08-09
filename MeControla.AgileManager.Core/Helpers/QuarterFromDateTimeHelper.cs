using System;
using System.Linq;

namespace MeControla.AgileManager.Core.Helpers
{
    public class QuarterFromDateTimeHelper : IQuarterFromDateTimeHelper
    {
        private static readonly int[] MONTHS_Q1 = new[] { 1, 2, 3 };
        private static readonly int[] MONTHS_Q2 = new[] { 4, 5, 6 };
        private static readonly int[] MONTHS_Q3 = new[] { 7, 8, 9 };

        public string GetQuarter(DateTime date)
        {
            if (MONTHS_Q1.Any(x => x.Equals(date.Month)))
                return $"Q1{date.Year}";

            if (MONTHS_Q2.Any(x => x.Equals(date.Month)))
                return $"Q2{date.Year}";

            if (MONTHS_Q3.Any(x => x.Equals(date.Month)))
                return $"Q3{date.Year}";

            return $"Q4{date.Year}";
        }
    }
}