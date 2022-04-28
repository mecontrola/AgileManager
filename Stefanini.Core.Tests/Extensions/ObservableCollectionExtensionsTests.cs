using FluentAssertions;
using Stefanini.Core.Extensions;
using Stefanini.Core.Tests.Mocks.Primitives;
using System.Collections.ObjectModel;
using Xunit;

namespace Stefanini.Core.Tests.Extensions
{
    public class ObservableCollectionExtensionsTests
    {
        [Fact(DisplayName = "[ObservableCollectionExtensions.AddList] Deve limpar e preencher o observable collection com os dados de enumerable quando o observable collection estiver vazio.")]
        public void DeveLimparEPreencherCollectionQuandoEstiverVazia()
            => RunAndAssertion(ObservableCollectionMock.CreateEmpty(), ObservableCollectionMock.CreateFill2());

        [Fact(DisplayName = "[ObservableCollectionExtensions.AddList] Deve limpar e preencher o observable collection com os dados de enumerable quando o observable collection não estiver vazio.")]
        public void DeveLimparEPreencherCollectionQuandoEstiverPreenchida()
            => RunAndAssertion(ObservableCollectionMock.CreateFill(), ObservableCollectionMock.CreateFill2());

        private static void RunAndAssertion(ObservableCollection<string> actual, ObservableCollection<string> expected)
        {
            actual.AddList(IEnumerableMock.CreateFill());
            actual.Should().BeEquivalentTo(expected);
        }
    }
}