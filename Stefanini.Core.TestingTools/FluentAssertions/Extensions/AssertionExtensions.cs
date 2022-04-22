using Microsoft.Extensions.DependencyInjection;

namespace Stefanini.Core.TestingTools.FluentAssertions.Extensions
{
    public static class AssertionExtensions
    {
        public static ServiceCollectionAssertions Should(this IServiceCollection services)
            => new(services);
    }
}