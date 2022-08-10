using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface IGenerateWeeksFromRangeDateHelper
    {
        IDictionary<string, Tuple<DateTime, DateTime>> GenerateList(DateTime dateIni, DateTime dateEnd);
        IDictionary<string, Tuple<DateTime, DateTime>> GenerateList(DateTime dateIni, DateTime dateEnd, int groupWeekBy);
    }
}