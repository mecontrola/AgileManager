using FluentAssertions;
using Stefanini.ViaReport.Core.Tests.Mocks.Builders.Jira;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Data.Dtos.Jira.Inputs;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Builders.Jira
{
    public class SearchInputDtoBuilderTests
    {
        [Fact(DisplayName = "[SearchInputDtoBuilder.ToBuild] Deve gerar dados de busca com parametros de busca padrao.")]
        public void DeveGerarDadosBuscaDefault()
        {
            var expected = SearchInputDtoMock.CreateWithCriteriaProjectOrderByKey();
            var actual = SearchInputDtoBuilderMock.CreateJqlCriteriaProjectOrderByKey().ToBuild();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[SearchInputDtoBuilder.StartAt] Deve gerar dados de bsuca com alteração no campo start at.")]
        public void DeveGerarDadosBuscaStartAtCustomizado()
        {
            var expected = SearchInputDtoMock.CreateWithCriteriaProjectOrderByKeyAndStartAt256();
            var actual = SearchInputDtoBuilderMock.CreateJqlCriteriaProjectOrderByKeyWithStartAt256().ToBuild();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[SearchInputDtoBuilder.MaxResults] Deve gerar dados de bsuca com alteração no campo max results.")]
        public void DeveGerarDadosBuscaMaxResultsCustomizado()
        {
            var expected = SearchInputDtoMock.CreateWithCriteriaProjectOrderByKeyAndMaxResults512();
            var actual = SearchInputDtoBuilderMock.CreateJqlCriteriaProjectOrderByKeyWithMaxResults512().ToBuild();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[SearchInputDtoBuilder.Fields] Deve gerar dados de bsuca com alteração no campo fields.")]
        public void DeveGerarDadosBuscaFieldsCustomizado()
        {
            var expected = SearchInputDtoMock.CreateWithCriteriaProjectOrderByKeyAndFieldsStatusAndSummary();
            var actual = SearchInputDtoBuilderMock.CreateJqlCriteriaProjectOrderByKeyWithFieldsStatusAndSummary().ToBuild();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}