using FluentAssertions;
using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Core.Tests.Mocks.Configurations;
using MeControla.AgileManager.Core.Tests.Mocks.Primitives;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Extensions
{
    public class ConfigurationExtensionsTests
    {
        [Fact(DisplayName = "[ConfigurationExtensions.GetJiraConfiguration] Deve retornar as informações de configurado do Jira no arquivo de configuração.")]
        public void DeveRetornarJiraConfiguration()
        {
            var configuration = IConfigurationMock.CreateWithJiraConfiguration();
            var expected = JiraConfigurationMock.Create();
            var actual = configuration.GetJiraConfiguration();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}