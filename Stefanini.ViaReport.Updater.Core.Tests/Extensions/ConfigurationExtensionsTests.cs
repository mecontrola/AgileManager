using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Stefanini.ViaReport.Updater.Core.Extensions;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Configurations;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Primitives;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Extensions
{
    public class ConfigurationExtensionsTests
    {
        private readonly IConfiguration configuration;

        public ConfigurationExtensionsTests()
        {
            configuration = ConfigurationMock.CreateEmptyConfigurationInstance();
        }

        [Fact(DisplayName = "[IConfiguration.GetUpdaterConfiguration] Deve retornar as informações de configuração do atualizador.")]
        public void DeveRetornarDadosConfiguracao()
        {
            var expected = UpdaterConfigurationMock.Create();
            var actual = configuration.GetUpdaterConfiguration();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}