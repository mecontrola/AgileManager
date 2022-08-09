using FluentAssertions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Helpers
{
    public class BusinessDayHelperTests
    {
        private const int DAYS_WITH_HOLIDAYS = 200;
        private const int DAYS_WITHOUT_HOLIDAYS = 202;

        private static readonly DateTime[] HOLIDAYS = new DateTime[]
        {
            new DateTime(2000, 9, 7), new DateTime(2000, 10, 12), new DateTime(2000, 11, 15), new DateTime(2000, 12, 25),
            new DateTime(2022, 3, 1)
        };

        private readonly IBusinessDayHelper helper;

        public BusinessDayHelperTests()
        {
            helper = new BusinessDayHelper();
        }

        [Fact(DisplayName = "[BusinessDayHelper.Diff] Deve retornar 0 quando for informado a data inicial e final iguais.")]
        public void DeveCalcularZeroQuandoDatasIguais()
        {
            var date = new DateTime(2022, 02, 28);
            var actual = helper.Diff(date, date);
            actual.Should().Be(0);
        }

        [Fact(DisplayName = "[BusinessDayHelper.Diff] Deve retornar 0 quando for informado a data inicial e o dia seguinte feriado.")]
        public void DeveCalcularZeroQuandoDatasIguais2()
        {
            var startDate = new DateTime(2022, 2, 28);
            var endDate = new DateTime(2022, 3, 1);
            var actual = helper.Diff(startDate, endDate, HOLIDAYS);
            actual.Should().Be(0);
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

        [Theory(DisplayName = "[BusinessDayHelper.Diff] Deve realizar o calculo da diferença entre duas datas considerando somente os dias úteis e desconsiderando feriados.")]
        [MemberData(nameof(GetEnumeratorCases))]
        public void DeveCalcularDiferencaDiasUteisDesconsiderandoFeriadoNasIssues(string issueKey, string startDate, string endDate, decimal expected)
        {
            var actual = helper.Diff(ConvertTime(startDate), ConvertTime(endDate));
            actual.Should().Be(expected, $"Issue {issueKey}");
        }

        private static DateTime ConvertTime(string dateTime)
            => DateTime.ParseExact(dateTime, "dd/M/yyyy h:mm tt", CultureInfo.InvariantCulture);

        public static IEnumerable<object[]> GetEnumeratorCases()
        {
            yield return new object[] { "SEA-273", "04/3/2022 9:40 AM", "04/3/2022 04:13 PM", 0 };
            yield return new object[] { "SEA-267", "25/2/2022 10:13 AM", "02/3/2022 09:03 AM", 3 };
            yield return new object[] { "SEA-266", "25/2/2022 10:14 AM", "03/3/2022 10:57 AM", 4 };
            yield return new object[] { "SEA-264", "24/2/2022 9:17 AM", "03/3/2022 10:57 AM", 5 };
            yield return new object[] { "SEA-262", "02/3/2022 2:07 PM", "03/3/2022 10:57 AM", 1 };
            yield return new object[] { "SEA-259", "23/2/2022 9:23 AM", "03/3/2022 10:54 AM", 6 };
            yield return new object[] { "SEA-257", "14/2/2022 3:25 PM", "21/2/2022 08:47 AM", 5 };
            yield return new object[] { "SEA-255", "14/2/2022 3:17 PM", "25/2/2022 08:51 AM", 9 };
            yield return new object[] { "SEA-254", "14/2/2022 3:09 PM", "21/2/2022 8:46 AM", 5 };
            yield return new object[] { "SEA-248", "17/2/2022 6:47 PM", "22/2/2022 4:34 PM", 3 };
            yield return new object[] { "SEA-246", "11/2/2022 9:26 AM", "21/2/2022 8:47 AM", 6 };
            yield return new object[] { "SEA-245", "10/2/2022 11:33 AM", "21/2/2022 8:47 AM", 7 };
            yield return new object[] { "SEA-237", "18/2/2022 9:29 AM", "04/3/2022 8:57 AM", 10 };
            yield return new object[] { "SEA-236", "18/2/2022 9:29 AM", "04/3/2022 8:57 AM", 10 };
            yield return new object[] { "SEA-235", "16/2/2022 2:11 PM", "22/2/2022 4:35 PM", 4 };
            yield return new object[] { "SEA-234", "14/2/2022 3:19 PM", "22/2/2022 4:35 PM", 6 };
            yield return new object[] { "SEA-233", "14/2/2022 3:16 PM", "22/2/2022 4:35 PM", 6 };
            yield return new object[] { "SEA-232", "14/2/2022 3:12 PM", "21/2/2022 8:47 AM", 5 };
            yield return new object[] { "SEA-230", "04/2/2022 9:29 AM", "22/2/2022 4:34 PM", 12 };
            yield return new object[] { "SEA-219", "20/1/2022 9:34 AM", "22/2/2022 4:34 PM", 23 };
            yield return new object[] { "LOY-117", "21/2/2022 9:44 AM", "03/3/2022 9:44 AM", 8 };
            yield return new object[] { "LOY-111", "16/2/2022 12:05 PM", "21/2/2022 9:56 AM", 3 };
            yield return new object[] { "LOY-97", "08/2/2022 5:43 PM", "04/3/2022 9:49 AM", 18 };
            yield return new object[] { "LOY-94", "18/2/2022 5:08 PM", "02/3/2022 9:28 AM", 8 };
            yield return new object[] { "LOY-91", "08/2/2022 10:29 AM", "21/2/2022 9:54 AM", 9 };
            yield return new object[] { "LOY-88", "07/2/2022 6:24 PM", "23/2/2022 9:45 AM", 12 };
            yield return new object[] { "LOY-30", "24/11/2021 10:48 AM", "21/2/2022 9:52 AM", 63 };
        }
    }
}