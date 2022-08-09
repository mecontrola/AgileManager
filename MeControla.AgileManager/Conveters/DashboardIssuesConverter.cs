using MeControla.AgileManager.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace MeControla.AgileManager.Conveters
{
    public class DashboardIssuesConverter : IValueConverter
    {
        private const string LABEL_COLUMN_VALUE = "View Issues";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value == null
             ? string.Empty
             : LABEL_COLUMN_VALUE;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => (List<IssueDto>)value;
    }
}