using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.IoC;
using Stefanini.ViaReport.Core.Tests.TestUtils.FluentAssertions.Extensions;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class HelpersInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 13;

        [Fact(DisplayName = "[MappersInjector.AddMappers] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddHelpers());

        [Fact(DisplayName = "[MappersInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddHelpers();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.Should().HaveService<IAverageUpstreamDownstreamRateHelper>().WithImplementation<AverageUpstreamDownstreamRateHelper>().AsSingleton();
            serviceCollection.Should().HaveService<IBusinessDayHelper>().WithImplementation<BusinessDayHelper>().AsSingleton();
            serviceCollection.Should().HaveService<ICalculateGrowthToDoInProgressHelper>().WithImplementation<CalculateGrowthToDoInProgressHelper>().AsSingleton();
            serviceCollection.Should().HaveService<ICalculateUpstreamDownstreamRateHelper>().WithImplementation<CalculateUpstreamDownstreamRateHelper>().AsSingleton();
            serviceCollection.Should().HaveService<IDateTimeFromStringHelper>().WithImplementation<DateTimeFromStringHelper>().AsSingleton();
            serviceCollection.Should().HaveService<IGenerateWeeksFromRangeDateHelper>().WithImplementation<GenerateWeeksFromRangeDateHelper>().AsSingleton();
            serviceCollection.Should().HaveService<IProjectNameCfdEasyBIExportHelper>().WithImplementation<ProjectNameCfdEasyBIExportHelper>().AsSingleton();
            serviceCollection.Should().HaveService<IQuarterFromDateTimeHelper>().WithImplementation<QuarterFromDateTimeHelper>().AsSingleton();
            serviceCollection.Should().HaveService<IReadCFDFileExportHelper>().WithImplementation<ReadCFDFileExportHelper>().AsSingleton();
            serviceCollection.Should().HaveService<IRecoverDateTimeFirstStatusMatchBacklogHelper>().WithImplementation<RecoverDateTimeFirstStatusMatchBacklogHelper>().AsSingleton();
            serviceCollection.Should().HaveService<ISatinizeEasyBIDataHelper>().WithImplementation<SatinizeEasyBIDataHelper>().AsSingleton();
            serviceCollection.Should().HaveService<ISettingsHelper>().WithImplementation<SettingsHelper>().AsSingleton();
            serviceCollection.Should().HaveService<IWeekOfTheYearFormatHelper>().WithImplementation<WeekOfTheYearFormatHelper>().AsSingleton();
        }
    }
}