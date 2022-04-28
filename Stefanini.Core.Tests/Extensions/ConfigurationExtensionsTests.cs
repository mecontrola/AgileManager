using FluentAssertions;
using Stefanini.Core.Extensions;
using Stefanini.Core.Tests.Data.Entities;
using Stefanini.Core.Tests.Mocks.Entities;
using Stefanini.Core.Tests.Mocks.Primitives;
using Xunit;

namespace Stefanini.Core.Tests.Extensions
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
    }
}