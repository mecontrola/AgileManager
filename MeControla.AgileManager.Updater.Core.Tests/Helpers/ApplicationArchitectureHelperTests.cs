using FluentAssertions;
using MeControla.AgileManager.Updater.Core.Helpers;
using Xunit;

namespace MeControla.AgileManager.Updater.Core.Tests.Helpers
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