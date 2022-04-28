using Microsoft.Extensions.DependencyInjection;

namespace Stefanini.Core.TestingTools.FluentAssertions.Extensions
{
    public static class ServiceCollectionAssertionsExtensions
    {
        public static void ShouldAsSingleton<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
            => PrepareVerification<TService, TImplementation>(serviceCollection).AsSingleton();

        public static void ShouldAsScoped<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
            => PrepareVerification<TService, TImplementation>(serviceCollection).AsScoped();

        private static ServiceAssertions<TService> PrepareVerification<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
            => serviceCollection.Should()
                                .HaveService<TService>()
                                .WithImplementation<TImplementation>();
    }
}