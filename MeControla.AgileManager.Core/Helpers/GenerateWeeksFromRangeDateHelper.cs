using MeControla.Core.Extensions;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Helpers
{
    public class GenerateWeeksFromRangeDateHelper : IGenerateWeeksFromRangeDateHelper
    {
        private const int INCREASE_7_DAYS = 7;

        public IDictionary<string, Tuple<DateTime, DateTime>> GenerateList(DateTime dateIni, DateTime dateEnd)
            => GenerateList(dateIni, dateEnd, 1);

        public IDictionary<string, Tuple<DateTime, DateTime>> GenerateList(DateTime dateIni, DateTime dateEnd, int groupWeekBy)
        {
            var list = new Dictionary<string, Tuple<DateTime, DateTime>>();
            var firstDayOfWeekYear = GetFirstDayInWeekOfTheYear(dateIni, groupWeekBy);

            while (firstDayOfWeekYear < dateEnd)
            {
                var week = GetWeekOfTheYear(firstDayOfWeekYear, groupWeekBy);
                var year = firstDayOfWeekYear.Year;

                list.Add($"{week}|{year}", CreateRangeTuple(firstDayOfWeekYear, groupWeekBy));

                firstDayOfWeekYear = firstDayOfWeekYear.AddDays(Add7Days(groupWeekBy));
            }

            return list;
        }

        private static int Add7Days(int groupWeekBy)
            => INCREASE_7_DAYS * groupWeekBy;

        private static Tuple<DateTime, DateTime> CreateRangeTuple(DateTime date, int groupWeekBy)
            => Tuple.Create(date.Date, date.AddDays(Add7Days(groupWeekBy) - 1).Date);

        private static DateTime GetFirstDayInWeekOfTheYear(DateTime dateTime, int groupWeekBy)
        {
            var previousDate = dateTime.AddDays(-1);
            var week = GetWeekOfTheYear(dateTime, groupWeekBy);

            return GetWeekOfTheYear(previousDate, groupWeekBy) == week
                 ? GetFirstDayInWeekOfTheYear(previousDate, groupWeekBy)
                 : dateTime;
        }

        private static int GetWeekOfTheYear(DateTime dateTime, int groupWeekBy)
        {
            if (groupWeekBy > 1 && dateTime.Year != dateTime.AddDays(INCREASE_7_DAYS).Year)
                return 1;

            var week = dateTime.GetWeekOfYear();

            return ((week - (week % groupWeekBy)) / groupWeekBy) + (groupWeekBy == 1 ? 0 : 1);
        }
    }
}