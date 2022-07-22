using FluentAssertions;
using Stefanini.Core.Extensions;
using Stefanini.Core.Tests.Mocks;
using System;
using Xunit;

namespace Stefanini.Core.Tests.Extensions
{
    public class StringExtensionsTests
    {
        private const string TEXT_SPACES = "    Simply      String    Test    ";
        private const string TEXT_DECODE = "Simply String Test";
        private const string TEXT_ENCODE = "U2ltcGx5IFN0cmluZyBUZXN0";
        private const string TEXT_ENCODE_MD5 = "0e3236e917bab2788755a33017e174e6";

        [Fact(DisplayName = "[StringExtensions.Base64Encode] Deve realizar a codificação em base64 de um texto.")]
        public void DeveRealizarEncodeTexto()
        {
            var actual = TEXT_DECODE.Base64Encode();
            actual.Should().BeEquivalentTo(TEXT_ENCODE);
        }

        [Fact(DisplayName = "[StringExtensions.Base64Decode] Deve realizar a decodificação em base64 de um texto.")]
        public void DeveRealizarDecodeTexto()
        {
            var actual = TEXT_ENCODE.Base64Decode();
            actual.Should().BeEquivalentTo(TEXT_DECODE);
        }

        [Fact(DisplayName = "[StringExtensions.TrimAll] Deve remover o excesso de espaços em um texto.")]
        public void DeveRemoverExcessoEspacosTexto()
        {
            var actual = TEXT_SPACES.TrimAll();
            actual.Should().BeEquivalentTo(TEXT_DECODE);
        }

        [Fact(DisplayName = "[StringExtensions.ToMD5] Deve realizar a decodificação em MD5 de um texto.")]
        public void DeveRealizarEncodeMD5Texto()
        {
            var actual = TEXT_ENCODE.ToMD5();
            actual.Should().BeEquivalentTo(TEXT_ENCODE_MD5);
        }

        [Fact(DisplayName = "[StringExtensions.ToDateTime] Deve realizar conversão de uma valor DateTime em string para um DateTime.")]
        public void DeveRealizarConversaoStringValidaParaDateTime()
        {
            var expected = (DateTime?)DataMock.DATETIME_QUARTER_2_2000;
            var actual = DataMock.TEXT_DATETIME.ToDateTime();

            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[StringExtensions.ToDateTime] Deve realizar conversão de uma valor string vazia para um DateTime nulo.")]
        public void DeveRealizarConversaoStringVaziaParaDateTimeNull()
        {
            var actual = string.Empty.ToDateTime();

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StringExtensions.ToDateTime] Deve realizar conversão de uma valor decimal em string para um decimal.")]
        public void DeveRealizarConversaoStringValidaParaDecimal()
        {
            var expected = DataMock.DECIMAL_DEFAULT;
            var actual = DataMock.TEXT_DECIMAL.ToDecimal();

            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[StringExtensions.ToDecimal] Deve realizar conversão de uma valor string vazia para um decimal nulo.")]
        public void DeveRealizarConversaoStringVaziaParaDecimalNull()
        {
            var actual = string.Empty.ToDecimal();

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StringExtensions.ToDecimal] Deve realizar conversão de uma valor string somente texto para um decimal nulo.")]
        public void DeveRealizarConversaoStringSomenteTextoParaDecimalNull()
        {
            var actual = DataMock.VALUE_DEFAULT_TEXT.ToDecimal();

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StringExtensions.ToDecimal]  Deve realizar conversão de uma valor maior que valor decimal para um decimal nulo.")]
        public void DeveRealizarConversaoOverflowParaDecimalNull()
        {
            var actual = $"{decimal.MaxValue}4".ToDecimal();

            actual.Should().BeNull();
        }
    }
}