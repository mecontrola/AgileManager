using FluentAssertions;
using MeControla.AgileManager.TestingTools.FluentAssertions.Extensions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.IoC;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.IoC
{
    public class HelpersInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 15;

        [Fact(DisplayName = "[MappersInjector.AddMappers] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddHelpers());

        [Fact(DisplayName = "[MappersInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddHelpers();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.ShouldAsSingleton<IAverageUpstreamDownstreamRateHelper, AverageUpstreamDownstreamRateHelper>();
            serviceCollection.ShouldAsSingleton<IBusinessDayHelper, BusinessDayHelper>();
            serviceCollection.ShouldAsSingleton<ICalculateGrowthToDoInProgressHelper, CalculateGrowthToDoInProgressHelper>();
            serviceCollection.ShouldAsSingleton<ICalculateUpstreamDownstreamRateHelper, CalculateUpstreamDownstreamRateHelper>();
            serviceCollection.ShouldAsSingleton<ICheckChangelogTypeHelper, CheckChangelogTypeHelper>();
            serviceCollection.ShouldAsSingleton<IDateTimeFromStringHelper, DateTimeFromStringHelper>();
            serviceCollection.ShouldAsSingleton<IGenerateWeeksFromRangeDateHelper, GenerateWeeksFromRangeDateHelper>();
            serviceCollection.ShouldAsSingleton<IIssueFieldsValidationHelper, IssueFieldsValidationHelper>();
            serviceCollection.ShouldAsSingleton<IMountJiraUrlHelper, MountJiraUrlHelper>();
            serviceCollection.ShouldAsSingleton<IQuarterFromDateTimeHelper, QuarterFromDateTimeHelper>();
            serviceCollection.ShouldAsSingleton<IQuarterGenerateListHelper, QuarterGenerateListHelper>();
            serviceCollection.ShouldAsSingleton<IReadCFDFileExportHelper, ReadCFDFileExportHelper>();
            serviceCollection.ShouldAsSingleton<IRecoverDateTimeFirstStatusMatchBacklogHelper, RecoverDateTimeFirstStatusMatchBacklogHelper>();
            serviceCollection.ShouldAsSingleton<ISettingsHelper, SettingsHelper>();
            serviceCollection.ShouldAsSingleton<IWeekOfTheYearFormatHelper, WeekOfTheYearFormatHelper>();
        }
    }
}