using FluentAssertions;
using MeControla.Kernel.Extensions;
using MeControla.Kernel.Tests.Data.Enums;
using Xunit;

namespace MeControla.Kernel.Tests.Extensions
{
    public class EnumExtensionsTests
    {
        [Fact(DisplayName = "[FieldInfo.GetCustomAttribute] Deve retornar o atributo customizado quando existir.")]
        public void DeveRetornarAtributoQuandoExistir()
        {
            var actual = EnumTest.Element1.GetDescription();
            actual.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "[FieldInfo.GetCustomAttribute] Deve retornar null quando não existir atributo customizado.")]
        public void DeveRetornarNullQuandoAtributoInexistente()
        {
            var actual = EnumTest.Element2.GetDescription();
            actual.Should().BeNull();
        }
    }
}