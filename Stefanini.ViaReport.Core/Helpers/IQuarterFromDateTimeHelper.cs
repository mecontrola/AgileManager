using System;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IQuarterFromDateTimeHelper
    {
        string GetQuarter(DateTime date);
    }
}