using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface IQuarterGenerateListHelper
    {
        IList<string> Create(DateTime dateTime);
        IList<string> Create(DateTime dateTime, int length);
    }
}