using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IQuarterGenerateListHelper
    {
        IList<string> Create(DateTime dateTime);
        IList<string> Create(DateTime dateTime, int length);
    }
}