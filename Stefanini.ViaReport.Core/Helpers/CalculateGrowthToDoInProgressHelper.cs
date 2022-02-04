using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class CalculateGrowthToDoInProgressHelper : ICalculateGrowthToDoInProgressHelper
    {
        public IDictionary<GrowthTypes, IList<CFDInfoDto>> Execute(IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> values)
            => new Dictionary<GrowthTypes, IList<CFDInfoDto>>
            {
                { GrowthTypes.ToDo, GetValuesCalculatedGrowthToDo(values).ToList() },
                { GrowthTypes.InProgress, GetValuesCalculatedGrowthInProgress(values).ToList() }
            };

        private static IEnumerable<CFDInfoDto> GetValuesCalculatedGrowthToDo(IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> values)
        {
            var items = values[EasyBIReportColumnName.ToDo];

            for (int i = 1, l = items.Count; i < l; i++)
            {
                var previous = items[i - 1];
                var current = items[i];

                yield return new CFDInfoDto { Date = current.Date, Value = current.Value - previous.Value };
            }
        }

        private static IEnumerable<CFDInfoDto> GetValuesCalculatedGrowthInProgress(IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> values)
        {
            var itemsInProgress = values[EasyBIReportColumnName.InProgress];
            var itemsDone = values[EasyBIReportColumnName.Done];

            for (int i = 1, l = itemsDone.Count; i < l; i++)
            {
                var previousInProgress = itemsInProgress[i - 1];
                var currentInProgress = itemsInProgress[i];
                var previousDone = itemsDone[i - 1];
                var currentDone = itemsDone[i];

                yield return new CFDInfoDto { Date = currentDone.Date, Value = (currentDone.Value - previousDone.Value) + (currentInProgress.Value - previousInProgress.Value) };
            }
        }
    }
}