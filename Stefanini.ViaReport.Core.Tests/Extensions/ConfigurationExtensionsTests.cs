using FluentAssertions;
using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Extensions;
using Stefanini.ViaReport.Core.Tests.Data.Entities;
using Stefanini.ViaReport.Core.Tests.Mocks.Configurations;
using Stefanini.ViaReport.Core.Tests.Mocks.Entities;
using Stefanini.ViaReport.Core.Tests.Mocks.Primitives;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Extensions
{
    public class ConfigurationExtensionsTests
    {
        [Fact(DisplayName = "[ConfigurationExtensions.Load] Deve retornar uma instancia do objeto vazio quando as informações não existirem no arquivo de configurações.")]
        public void DeveRetornarObjetoVazioQuandoNaoExistir()
        {
            var configuration = IConfigurationMock.CreateEmpty();

            var actual = configuration.Load<ClassTestConfiguration>();
            var expected = ClassTestConfigurationMock.CreateEmpty();

            Assert(actual, expected);
        }

        [Fact(DisplayName = "[ConfigurationExtensions.Load] Deve retornar uma instancia do objeto preenchido quando as informações existirem no arquivo de configurações.")]
        public void DeveRetornarObjetoPreenchidoQuandoExistir()
        {
            var configuration = IConfigurationMock.Create();

            var actual = configuration.Load<ClassTestConfiguration>();
            var expected = ClassTestConfigurationMock.Create();

            Assert(actual, expected);
        }

        private static void Assert(ClassTestConfiguration actual, ClassTestConfiguration expected)
        {
            actual.Should().NotBeNull();
            actual.Should().BeOfType<ClassTestConfiguration>();
            actual.FieldInClass1.Should().Be(expected.FieldInClass1);
            actual.FieldInClass2.Should().Be(expected.FieldInClass2);
        }

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