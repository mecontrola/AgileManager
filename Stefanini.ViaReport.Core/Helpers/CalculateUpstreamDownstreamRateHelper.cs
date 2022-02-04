using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

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

                return new()
                {
                    Date = weekOfTheYearFormatHelper.Format(growthToDo.Date),
                    GrowthToDo = 0,
                    GrowthInProgress = 0,
                    UpstreamDownstreamRate = 0,
                    IsChecked = false
                };
            }

            if (previousGrowthInProgress == 0 || previousGrowthToDo == 0)
            {
                return new()
                {
                    Date = weekOfTheYearFormatHelper.Format(growthToDo.Date),
                    GrowthToDo = 0,
                    GrowthInProgress = 0,
                    UpstreamDownstreamRate = null,
                    IsChecked = false
                };
            }

            growthInProgress.Value = previousGrowthInProgress;
            growthToDo.Value = previousGrowthToDo;

            previousGrowthInProgress = 0;
            previousGrowthToDo = 0;

            return new()
            {
                Date = weekOfTheYearFormatHelper.Format(growthToDo.Date),
                GrowthToDo = growthToDo.Value,
                GrowthInProgress = growthInProgress.Value,
                UpstreamDownstreamRate = growthToDo.Value / growthInProgress.Value,
                IsChecked = false
            };
        }
    }
}