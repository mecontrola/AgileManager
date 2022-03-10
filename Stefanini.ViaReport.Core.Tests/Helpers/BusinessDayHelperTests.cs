using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class BusinessDayHelperTests
    {
        private const int DAYS_WITH_HOLIDAYS = 201;
        private const int DAYS_WITHOUT_HOLIDAYS = 203;

        private static readonly DateTime[] HOLIDAYS = new DateTime[]
        {
            new DateTime(2000, 9, 7), new DateTime(2000, 10, 12), new DateTime(2000, 11, 15), new DateTime(2000, 12, 25)
        };

        private readonly IBusinessDayHelper helper;

        public BusinessDayHelperTests()
        {
            helper = new BusinessDayHelper();
        }

        [Fact(DisplayName = "[BusinessDayHelper.Diff] Deve realizar o calculo da diferença entre duas datas considerando somente os dias úteis desconsiderando feriados.")]
        public void DeveCalcularDiferencaDiasUteis()
        {
            var actual = helper.Diff(DataMock.DATETIME_QUARTER_1_2000, DataMock.DATETIME_QUARTER_4_2000);
            actual.Should().Be(DAYS_WITHOUT_HOLIDAYS);
        }

        [Fact(DisplayName = "[BusinessDayHelper.Diff] Deve realizar o calculo da diferença entre duas datas considerando somente os dias úteis considerando feriados.")]
        public void DeveCalcularDiferencaDiasUteisDesconsiderandoFeriado()
        {
            var actual = helper.Diff(DataMock.DATETIME_QUARTER_1_2000, DataMock.DATETIME_QUARTER_4_2000, HOLIDAYS);
            actual.Should().Be(DAYS_WITH_HOLIDAYS);
        }

        [Fact(DisplayName = "[BusinessDayHelper.Diff] Deve gerar exceção quando a data final for menor que a data inicial.")]
        public void DeveGerarExcecaoQuandoDataInicialMaiorFinal()
        {
            var actual = () => { helper.Diff(DataMock.DATETIME_QUARTER_4_2000, DataMock.DATETIME_QUARTER_1_2000); };
            actual.Should().Throw<ArgumentException>();
        }
    }
}