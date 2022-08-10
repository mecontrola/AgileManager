using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.AgileManager.Core.Helpers
{
    public class QuarterGenerateListHelper : IQuarterGenerateListHelper
    {
        private const int LENGTH_DEFAULT = 6;
        private const int DAYS = 90;

        private readonly IQuarterFromDateTimeHelper quarterFromDateTimeHelper;

        public QuarterGenerateListHelper(IQuarterFromDateTimeHelper quarterFromDateTimeHelper)
        {
            this.quarterFromDateTimeHelper = quarterFromDateTimeHelper;
        }

        public IList<string> Create(DateTime dateTime)
            => Create(dateTime, LENGTH_DEFAULT);

        public IList<string> Create(DateTime dateTime, int length)
        {
            var dates = new List<DateTime>();

            for (int i = 0; i < length; i++)
            {
                dates.Add(dateTime);

                dateTime = dateTime.AddDays(-DAYS);
            }

            return dates.Select(x => quarterFromDateTimeHelper.GetQuarter(x))
                        .ToList();
        }
    }
}