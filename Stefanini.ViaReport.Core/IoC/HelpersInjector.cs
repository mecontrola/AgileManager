using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.Core.Helpers;
using System;

namespace Stefanini.ViaReport.Core.IoC
{
    public static class HelpersInjector
    {
        public static void AddHelpers(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddSingleton<IAverageUpstreamDownstreamRateHelper, AverageUpstreamDownstreamRateHelper>();
            services.TryAddSingleton<IBusinessDayHelper, BusinessDayHelper>();
            services.TryAddSingleton<ICalculateGrowthToDoInProgressHelper, CalculateGrowthToDoInProgressHelper>();
            services.TryAddSingleton<ICalculateUpstreamDownstreamRateHelper, CalculateUpstreamDownstreamRateHelper>();
            services.TryAddSingleton<IDateTimeFromStringHelper, DateTimeFromStringHelper>();
            services.TryAddSingleton<IGenerateWeeksFromRangeDateHelper, GenerateWeeksFromRangeDateHelper>();
            services.TryAddSingleton<IQuarterFromDateTimeHelper, QuarterFromDateTimeHelper>();
            services.TryAddSingleton<IQuarterGenerateListHelper, QuarterGenerateListHelper>();
            services.TryAddSingleton<IReadCFDFileExportHelper, ReadCFDFileExportHelper>();
            services.TryAddSingleton<IRecoverDateTimeFirstStatusMatchBacklogHelper, RecoverDateTimeFirstStatusMatchBacklogHelper>();
            services.TryAddSingleton<ISettingsHelper, SettingsHelper>();
            services.TryAddSingleton<IWeekOfTheYearFormatHelper, WeekOfTheYearFormatHelper>();
        }
    }
}