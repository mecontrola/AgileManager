using System;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IBusinessDayHelper
    {
        decimal Diff(DateTime firstDay, DateTime lastDay);
        decimal Diff(DateTime firstDay, DateTime lastDay, DateTime[] holidays);
    }
}