using Microsoft.Extensions.DependencyInjection;

namespace Stefanini.Core.TestingTools.FluentAssertions.Extensions
{
    public static class ServiceCollectionAssertionsExtensions
    {
        public static void ShouldAsSingleton<TService>(this IServiceCollection serviceCollection)
            where TService : class
            => PrepareVerification<TService>(serviceCollection).AsSingleton();

        public static void ShouldAsSingleton<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
            => PrepareVerificationWithImpl<TService, TImplementation>(serviceCollection).AsSingleton();

        public static void ShouldAsScoped<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
            => PrepareVerificationWithImpl<TService, TImplementation>(serviceCollection).AsScoped();

        public static void ShouldAsTransient<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
            => PrepareVerificationWithImpl<TService, TImplementation>(serviceCollection).AsTransient();

        private static ServiceAssertions<TService> PrepareVerification<TService>(this IServiceCollection serviceCollection)
            where TService : class
            => serviceCollection.Should()
                                .HaveService<TService>();

        private static ServiceAssertions<TService> PrepareVerificationWithImpl<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
            => serviceCollection.Should()
                                .HaveService<TService>()
                                .WithImplementation<TImplementation>();
    }
}