using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using System;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class IssueFieldsValidationHelperTests
    {
        private const string LABEL_INCIDENT = "Incidente";
        private const string LABEL_Q12022_NORMAL = "Q12022";
        private const string LABEL_Q12022_SPACE = "Q1 2022";
        private const string LABEL_Q12022_HYPEN = "Q1-2022";
        private const string LABEL_Q12022_LOWER = "q12022";
        private const string LABEL_Q12022_INVALID = "quarter12022";

        private readonly IIssueFieldsValidationHelper helper;

        public IssueFieldsValidationHelperTests()
        {
            helper = new IssueFieldsValidationHelper();
        }

        [Fact(DisplayName = "[IssueFieldsValidationHelper.HasLabelIndicent] Deve retornar true quando a lista informada conter um label de incidente válido")]
        public void DeveRetornarTrueQuandoConterLabelInIncidenteValido()
            => helper.HasLabelIndicent(new string[] { LABEL_INCIDENT })
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.HasLabelIndicent] Deve retornar false quando a lista informada conter label de incidente inválido.")]
        public void DeveRetornarFalseQuandoConterLabelIncidenteInvalido()
            => helper.HasLabelIndicent(new string[] { LABEL_Q12022_NORMAL })
                     .Should()
                     .BeFalse();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.HasLabelIndicent] Deve retornar false quando a lista informada estiver vazia.")]
        public void DeveRetornarFalseQuandoListaLabelIncidenteVazio()
            => helper.HasLabelIndicent(Array.Empty<string>())
                     .Should()
                     .BeFalse();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.IsEpicIssueType] Deve retornar true quando a issue informada for do tipo épico.")]
        public void DeveRetornarTrueQuandoIssueInformadaForEpico()
            => helper.IsEpicIssueType(IssueDtoMock.CreateAllFilledEpic())
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.IsEpicIssueType] Deve retornar true quando a issue informada não for do tipo épico.")]
        public void DeveRetornarFalseQuandoIssueInformadaNaoForEpico()
            => helper.IsEpicIssueType(IssueDtoMock.CreateAllFilledStory())
                     .Should()
                     .BeFalse();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.HasLabelQuarter] Deve retornar true quando a lista informada conter um label de quarter válido")]
        public void DeveRetornarTrueQuandoConterLabelQuarterValida()
            => helper.HasLabelQuarter(new string[] { LABEL_Q12022_NORMAL })
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.HasLabelQuarter] Deve retornar false quando a lista informada conter labels inválidos.")]
        public void DeveRetornarFalseQuandoConterLabelQuarterInvalida()
            => helper.HasLabelQuarter(new string[] { LABEL_INCIDENT })
                     .Should()
                     .BeFalse();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.HasLabelQuarter] Deve retornar false quando a lista informada estiver vazia.")]
        public void DeveRetornarFalseQuandoListaLabelQuarterVazia()
            => helper.HasLabelQuarter(Array.Empty<string>())
                     .Should()
                     .BeFalse();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o true quando o label informado for no formato letra q maiúscula seguido de 5 números.")]
        public void DeveRetornarTrueQuandoFormatoNormal()
            => helper.IsLabelQuarter(LABEL_Q12022_NORMAL)
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o true quando o label informado for no formato letra q maiúscula e seguido de 5 números, sendo o primeiro número separado por espaço.")]
        public void DeveRetornarTrueQuandoFormatoContemEspaco()
            => helper.IsLabelQuarter(LABEL_Q12022_SPACE)
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o true quando o label informado for no formato letra q maiúscula e seguido de 5 números, sendo o primeiro número separado por hífen.")]
        public void DeveRetornarTrueQuandoFormatoContemHifen()
            => helper.IsLabelQuarter(LABEL_Q12022_HYPEN)
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o true quando o label informado for no formato letra q minúscula seguido de 5 números.")]
        public void DeveRetornarTrueQuandoFormatoNormalMinusculo()
            => helper.IsLabelQuarter(LABEL_Q12022_LOWER)
                     .Should()
                     .BeTrue();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o false quando o label informado for inválido.")]
        public void DeveRetornarFalseQuandoFormatoInvalido()
            => helper.IsLabelQuarter(LABEL_Q12022_INVALID)
                     .Should()
                     .BeFalse();

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o nome do quarter satinizado quando for um label válido.")]
        public void DeveRetornarSatinizadoQuandoFormatoNormal()
            => helper.SatinizeLabelQuarter(LABEL_Q12022_NORMAL)
                     .Should()
                     .BeEquivalentTo(LABEL_Q12022_NORMAL);

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o nome do quarter satinizado quando for um label tiver formato com espaço.")]
        public void DeveRetornarSatinizadoQuandoFormatoContemEspaco()
            => helper.SatinizeLabelQuarter(LABEL_Q12022_SPACE)
                     .Should()
                     .BeEquivalentTo(LABEL_Q12022_NORMAL);

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o nome do quarter satinizado quando for um label tiver formato com hifen.")]
        public void DeveRetornarSatinizadoQuandoFormatoContemHifen()
            => helper.SatinizeLabelQuarter(LABEL_Q12022_HYPEN)
                     .Should()
                     .BeEquivalentTo(LABEL_Q12022_NORMAL);

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar o nome do quarter satinizado quando for um label tiver formato com letras minúsculas.")]
        public void DeveRetornarSatinizadoQuandoFormatoContemMinusculo()
            => helper.SatinizeLabelQuarter(LABEL_Q12022_LOWER)
                     .Should()
                     .BeEquivalentTo(LABEL_Q12022_NORMAL);

        [Fact(DisplayName = "[IssueFieldsValidationHelper.SatinizeLabelQuarter] Deve retornar vazio quando for um label tiver formato inválido.")]
        public void DeveRetornarVazioQuandoFormatoInvalido()
            => helper.SatinizeLabelQuarter(LABEL_Q12022_INVALID)
                     .Should()
                     .BeNullOrEmpty();
    }
}