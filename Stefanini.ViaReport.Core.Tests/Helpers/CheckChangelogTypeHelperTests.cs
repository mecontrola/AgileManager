using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class CheckChangelogTypeHelperTests
    {
        private readonly ICheckChangelogTypeHelper helper;

        public CheckChangelogTypeHelperTests()
        {
            helper = new CheckChangelogTypeHelper();
        }

        [Fact(DisplayName = "[CheckChangelogTypeHelper.IsFieldStatus] Deve retornar true quando histórico informado for do tipo status.")]
        public void DeveRetornarTrueQuandoHistoricoForStatus()
            => helper.IsFieldStatus(HistoryItemDtoMock.CreateStatus())
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[CheckChangelogTypeHelper.IsFieldStatus] Deve retornar true quando histórico informado não for do tipo status.")]
        public void DeveRetornarFalseQuandoHistoricoNaoForStatus()
            => helper.IsFieldStatus(HistoryItemDtoMock.CreateImpediment())
                     .Should()
                     .BeFalse();

        [Fact(DisplayName = "[CheckChangelogTypeHelper.IsFieldStatus] Deve retornar true quando histórico informado for do tipo flag.")]
        public void DeveRetornarTrueQuandoHistoricoForFlag()
            => helper.IsFieldFlagged(HistoryItemDtoMock.CreateImpediment())
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[CheckChangelogTypeHelper.IsFieldStatus] Deve retornar true quando histórico informado não for do tipo flag.")]
        public void DeveRetornarFalseQuandoHistoricoNaoForFlag()
            => helper.IsFieldFlagged(HistoryItemDtoMock.CreateStatus())
                     .Should()
                     .BeFalse();
    }
}