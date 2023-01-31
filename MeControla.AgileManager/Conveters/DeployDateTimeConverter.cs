using System;
using System.Globalization;
using System.Windows.Data;

namespace MeControla.AgileManager.Conveters
{
    public class DeployDateTimeConverter : IValueConverter
    {
        private static readonly string DEFAULT_VALUE = "TBD";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(DateTime))
                return DEFAULT_VALUE;

            return $"{((DateTime)value):dd/MM/yyyy}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            return DateTime.Parse(value.ToString());
        }
    }
}