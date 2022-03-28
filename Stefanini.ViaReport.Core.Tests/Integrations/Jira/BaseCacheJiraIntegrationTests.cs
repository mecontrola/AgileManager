using FluentAssertions;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Integrations.Jira;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira
{
    public class BaseCacheJiraIntegrationTests
    {
        [Fact(DisplayName = "[BaseCacheJiraIntegration.SaveFile1|LoadFile] Deve salvar o arquivo de cache e carregar em seguida.")]
        public void DeveSalvarCarregarCache()
        {
            var cache = BaseCacheJiraIntegrationMock.Create();
            cache.ClearFiles();

            cache.SaveFile();

            cache.LoadFile().Should().Be(DataMock.JSON_CLASS_TEST);

            cache.ClearFiles();
        }

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