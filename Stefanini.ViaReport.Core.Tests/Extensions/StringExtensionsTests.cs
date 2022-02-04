using FluentAssertions;
using Stefanini.Core.Extensions;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Extensions
{
    public class StringExtensionsTests
    {
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

        [Fact(DisplayName = "[StringExtensions.ToMD5] Deve realizar a decodificação em MD5 de um texto.")]
        public void DeveRealizarEncodeMD5Texto()
        {
            var actual = TEXT_ENCODE.ToMD5();
            actual.Should().BeEquivalentTo(TEXT_ENCODE_MD5);
        }
    }
}