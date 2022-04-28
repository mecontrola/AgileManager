using FluentAssertions;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Helpers
{
    public class ApplicationArchitectureHelperTests
    {
        private readonly IApplicationArchitectureHelper helper;

        public ApplicationArchitectureHelperTests()
        {
            helper = new ApplicationArchitectureHelper();
        }

        [Fact(DisplayName = "[ApplicationArchitectureHelper]")]
        public void DeveRetornarTrueQuandoArquiteturax64()
            => helper.Isx64()
                     .Should()
                     .BeTrue();
    }
}