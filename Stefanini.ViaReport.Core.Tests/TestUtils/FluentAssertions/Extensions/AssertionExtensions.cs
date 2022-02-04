using Microsoft.Extensions.DependencyInjection;

namespace Stefanini.ViaReport.Core.Tests.TestUtils.FluentAssertions.Extensions
{
    public static class AssertionExtensions
    {
        public static ServiceCollectionAssertions Should(this IServiceCollection services)
            => new(services);
    }
}