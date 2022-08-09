using FluentAssertions;
using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Core.Tests.Mocks;
using System.Collections.Generic;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Extensions
{
    public class DatagridExtensionsTests
    {
        private static readonly IList<string> EXPECTED = new List<string> { "Cart", "Choose", "Core Apps" };

        [Fact(DisplayName = "[DatagridExtensions.GetSelectedItems<T>] Deve retornar uma lista itens que comecem com a lista C.")]
        public void DeveRetornarListaDeAcordoComCriterio()
        {
            var actual = DataMock.LIST_PROJECT_CATEGORIES_APLICATIVOS
                                 .GetSelectedItems<string>(x => x.ToLower().StartsWith("c"));
            actual.Should().BeEquivalentTo(EXPECTED);
        }

        [Fact(DisplayName = "[DatagridExtensions.GetSelectedItems<T>] Retorna lista vazia quando a lista informada for null.")]
        public void DeveRetornarListaVaziaQuandoListaNull()
        {
            var actual = CreateNull().GetSelectedItems<string>(x => true);
            actual.Should().BeEmpty();
        }

        private static IEnumerable<string> CreateNull()
            => null;
    }
}