using FluentAssertions;
using Stefanini.Core.Extensions;
using System;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Extensions
{
    public class StringVersionExtensionTests
    {
        private readonly Version EXPECTED = new(1, 3, 4, 5);

        private const string ACTUAL_WITH_V = "v1.3.4.5";
        private const string ACTUAL_WITHOUT_V = "1.3.4.5";

        [Fact(DisplayName = "[StringVersionExtension.GetVersion] Deve retornar null quando a string informada for vazia.")]
        public void DeveRetornaNullQuandoVazia()
            => string.Empty
                     .GetVersion()
                     .Should()
                     .BeNull();

        [Fact(DisplayName = "[StringVersionExtension.GetVersion] Deve retornar Version quando a string informada iniciar com v.")]
        public void DeveRetornaVersionQuandoStringComV()
            => ACTUAL_WITH_V.GetVersion()
                            .Should()
                            .BeEquivalentTo(EXPECTED);

        [Fact(DisplayName = "[StringVersionExtension.GetVersion] Deve retornar Version quando a string informada não tiver v.")]
        public void DeveRetornaVersionQuandoStringSemV()
            => ACTUAL_WITHOUT_V.GetVersion()
                               .Should()
                               .BeEquivalentTo(EXPECTED);
    }
}