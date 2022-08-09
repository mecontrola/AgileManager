using System;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface IBusinessDayHelper
    {
        decimal Diff(DateTime firstDay, DateTime lastDay);
        decimal Diff(DateTime firstDay, DateTime lastDay, DateTime[] holidays);
    }
}