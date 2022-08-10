using System;
using System.Globalization;
using System.Windows.Data;

namespace MeControla.AgileManager.Conveters
{
    public class LinkIssueConverter : IValueConverter
    {
        private const string LABEL_COLUMN_VALUE = "Open";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value == null
             ? string.Empty
             : LABEL_COLUMN_VALUE;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => new Uri((string)value);
    }
}