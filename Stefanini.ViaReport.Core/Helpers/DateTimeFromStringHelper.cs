using System;
using System.Text.RegularExpressions;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class DateTimeFromStringHelper : IDateTimeFromStringHelper
    {
        private const string REGEX_DATETIME_KEY = "date";
        private const string REGEX_DATETIME = @"^W[0-9]{1,2},\s(?<date>.*)$";

        public DateTime Convert(string dateTime)
        {
            dateTime = GetDateFromString(dateTime);
            return string.IsNullOrWhiteSpace(dateTime)
                 ? DateTime.MinValue
                 : System.Convert.ToDateTime(dateTime);
        }

        private static string GetDateFromString(string dateTime)
        {
            var regex = Regex.Match(dateTime, REGEX_DATETIME);
            return !regex.Success
                 ? string.Empty
                 : regex.Groups[REGEX_DATETIME_KEY].Value;
        }
    }
}