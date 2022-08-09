using FluentAssertions;
using Microsoft.Extensions.Configuration;
using MeControla.AgileManager.Updater.Core.Extensions;
using MeControla.AgileManager.Updater.Core.Tests.Mocks.Configurations;
using MeControla.AgileManager.Updater.Core.Tests.Mocks.Primitives;
using Xunit;

namespace MeControla.AgileManager.Updater.Core.Tests.Extensions
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