using FluentAssertions;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Integrations.Jira;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira
{
    [TestCaseOrderer("Xunit.FactPriorityOrderer", "RunCacheTestsOrder")]
    public class BaseCacheJiraIntegrationTests
    {
        [FactPriority(1)]
        [Fact(DisplayName = "[BaseCacheJiraIntegration.SaveFile1|LoadFile] Deve salvar o arquivo de cache e carregar em seguida.")]
        public void DeveSalvarCarregarCache()
        {
            var cache = BaseCacheJiraIntegrationMock.Create();
            cache.ClearFiles();

            cache.SaveFile();

            cache.LoadFile().Should().Be(DataMock.JSON_CLASS_TEST);

            cache.ClearFiles();
        }

        [FactPriority(2)]
        [Fact(DisplayName = "[BaseCacheJiraIntegration.IsLoadCachedFile] Deve retornar false quando o cache estiver desligado.")]
        public void DeveRetornarFalseQuandoCacheInativo()
        {
            var cache = BaseCacheJiraIntegrationMock.Create();
            cache.ClearFiles();

            cache.IsLoadCachedFile().Should().BeFalse();

            cache.SaveFile();

            cache.IsLoadCachedFile().Should().BeFalse();

            cache.ClearFiles();
        }

        [FactPriority(3)]
        [Fact(DisplayName = "[BaseCacheJiraIntegration.IsLoadCachedFile] Deve retornar true quando o tempo de existência do arquivo é maior que o de cache.")]
        public void DeveRetornarTrueQuandoTempoMaiorQueConfigurado()
        {
            var cache = BaseCacheJiraIntegrationMock.CreateWithCache();
            cache.ClearFiles();

            cache.IsLoadCachedFile().Should().BeFalse();

            cache.SaveFile();

            cache.IsLoadCachedFile().Should().BeTrue();

            cache.ClearFiles();
        }

        [FactPriority(4)]
        [Fact(DisplayName = "[BaseCacheJiraIntegration.IsLoadCachedFile] Deve retornar false quando o tempo de existência do arquivo é menor que o de cache.")]
        public void DeveRetornarFalseQuandoTempoMenorQueConfigurado()
        {
            var cache = BaseCacheJiraIntegrationMock.CreateWithCache();
            cache.ClearFiles();

            cache.IsLoadCachedFile().Should().BeFalse();

            cache.SaveFile();

            cache.ChangeLastAccessTimeTo1HourAgo();

            cache.IsLoadCachedFile().Should().BeFalse();

            cache.ClearFiles();
        }
    }
}