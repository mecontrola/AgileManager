using FluentAssertions;
using Stefanini.ViaReport.Core.Extensions;
using Stefanini.ViaReport.Core.Tests.Mocks.Configurations;
using Stefanini.ViaReport.Core.Tests.Mocks.Primitives;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Extensions
{
    public class ConfigurationExtensionsTests
    {
        [Fact(DisplayName = "[ConfigurationExtensions.GetApplicationConfiguration] Deve retornar as informações de configurado da aplicação no arquivo de configuração.")]
        public void DeveRetornarApplicationConfiguration()
        {
            var configuration = IConfigurationMock.CreateWithAppAndJiraConfiguration();
            var expected = ApplicationConfigurationMock.Create();
            var actual = configuration.GetApplicationConfiguration();

            actual.Should().BeEquivalentTo(expected);
        }


        [Fact(DisplayName = "[ConfigurationExtensions.GetJiraConfiguration] Deve retornar as informações de configurado do Jira no arquivo de configuração.")]
        public void DeveRetornarJiraConfiguration()
        {
            var configuration = IConfigurationMock.CreateWithAppAndJiraConfiguration();
            var expected = JiraConfigurationMock.Create();
            var actual = configuration.GetJiraConfiguration();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}