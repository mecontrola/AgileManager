using FluentAssertions;
using MeControla.Kernel.Extensions;
using MeControla.Kernel.Tests.Mocks.Primitives;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Kernel.Tests.Extensions
{
    public class CollectionExtensionsTests
    {
        [Fact(DisplayName = "[CollectionExtensions.AddList] Deve limpar e preencher collection com os dados de enumerable quando a collection estiver vazia.")]
        public void DeveLimparEPreencherCollectionQuandoEstiverVazia()
            => RunAndAssertion(ICollectionMock.CreateEmpty());

        [Fact(DisplayName = "[CollectionExtensions.AddList] Deve limpar e preencher collection com os dados de enumerable quando a collection não estiver vazia.")]
        public void DeveLimparEPreencherCollectionQuandoEstiverPreenchida()
            => RunAndAssertion(ICollectionMock.CreateFill());

        private static void RunAndAssertion(ICollection<string> actual)
        {
            actual.AddList(IEnumerableMock.CreateFill());
            actual.Should().BeEquivalentTo(ICollectionMock.CreateFill2());
        }
    }
}