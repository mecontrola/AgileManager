using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class CalculateUpstreamDownstreamRateHelper : ICalculateUpstreamDownstreamRateHelper
    {
        private readonly IWeekOfTheYearFormatHelper weekOfTheYearFormatHelper;

        private decimal? previousGrowthInProgress = 0;
        private decimal? previousGrowthToDo = 0;

        public CalculateUpstreamDownstreamRateHelper(IWeekOfTheYearFormatHelper weekOfTheYearFormatHelper)
        {
            this.weekOfTheYearFormatHelper = weekOfTheYearFormatHelper;
        }

        public IList<AHMInfoDto> Execute(IDictionary<GrowthTypes, IList<CFDInfoDto>> data)
        {
            var items = new List<AHMInfoDto>();

            for (int i = 0, l = data[GrowthTypes.InProgress].Count; i < l; i++)
                items.Add(CreateAHMInfoItem(data[GrowthTypes.ToDo][i], data[GrowthTypes.InProgress][i]));

            return items;
        }

        private AHMInfoDto CreateAHMInfoItem(CFDInfoDto growthToDo, CFDInfoDto growthInProgress)
        {
            previousGrowthInProgress += growthInProgress.Value;
            previousGrowthToDo += growthToDo.Value;

            if (previousGrowthInProgress == 0 && previousGrowthToDo == 0)
            {
                previousGrowthInProgress = 0;
                previousGrowthToDo = 0;

                return CreateAHMInfo(growthToDo.Date, 0, 0);
            }

            if (previousGrowthInProgress == 0 || previousGrowthToDo == 0)
                return CreateAHMInfo(growthToDo.Date, null, null);

            var growthInProgressValue = previousGrowthInProgress;
            var growthToDoValue = previousGrowthToDo;

            previousGrowthInProgress = 0;
            previousGrowthToDo = 0;

            return CreateAHMInfo(growthToDo.Date, growthToDoValue, growthInProgressValue);
        }

        private AHMInfoDto CreateAHMInfo(DateTime date, decimal? growthToDo, decimal? growthInProgress)
            => new()
            {
                Date = weekOfTheYearFormatHelper.Format(date),
                GrowthToDo = growthToDo ?? 0,
                GrowthInProgress = growthInProgress ?? 0,
                UpstreamDownstreamRate = CalculateRate(growthToDo, growthInProgress),
                IsChecked = false
            };

        private static decimal? CalculateRate(decimal? growthToDo, decimal? growthInProgress)
        {
            if (!growthToDo.HasValue || !growthInProgress.HasValue)
                return null;

            if (growthToDo.Value == 0 && growthInProgress.Value == 0)
                return 0;

            return growthToDo.Value / growthInProgress.Value;
        }
    }
}