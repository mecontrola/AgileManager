using Microsoft.Extensions.DependencyInjection;

namespace MeControla.AgileManager.TestingTools.FluentAssertions.Extensions
{
    public static class AssertionExtensions
    {
        public static ServiceCollectionAssertions Should(this IServiceCollection services)
            => new(services);
    }
}