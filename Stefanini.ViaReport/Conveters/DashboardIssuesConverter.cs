using Stefanini.ViaReport.Core.Data.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Stefanini.ViaReport.Conveters
{
    public class DashboardIssuesConverter : IValueConverter
    {
        private const string LABEL_COLUMN_VALUE = "View Issues";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value == null
             ? string.Empty
             : LABEL_COLUMN_VALUE;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => (List<IssueInfoDto>)value;
    }
}