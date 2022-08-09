using FluentAssertions;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using System;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Helpers
{
    public class ReadCFDFileExportHelperTests : BaseAsyncMethods
    {
        private readonly IReadCFDFileExportHelper helper;

        public ReadCFDFileExportHelperTests()
        {
            var dateTimeFromStringHelper = new DateTimeFromStringHelper();

            helper = new ReadCFDFileExportHelper(dateTimeFromStringHelper);
        }

        [Fact(DisplayName = "[ReadCFDFileExportHelper.GetData] Deve ler todas as informações do relatório CFD do arquivo CSV e converter em uma lista.")]
        public async void DeveConverterDadosCSVParaObjeto()
        {
            var expected = CFDInfoDtoMock.CreateCheckFile();
            var actual = await helper.GetData(DataMock.FILENAMA_CFD_CSV_IMPORT, GetCancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ReadCFDFileExportHelper.GetData] Deve gerar uma exceção quando o arquivo for encotnrado.")]
        public async void DeveDispararExcecaoQuandoArquivoInvalido()
        {
            var actual = () => helper.GetData(string.Empty, GetCancellationToken());

            await actual.Should().ThrowAsync<ArgumentException>();
        }
    }
}