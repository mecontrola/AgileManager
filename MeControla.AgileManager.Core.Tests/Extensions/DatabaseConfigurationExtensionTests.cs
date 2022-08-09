using FluentAssertions;
using MeControla.AgileManager.Core.Tests.IoC;
using MeControla.AgileManager.DataStorage;
using MeControla.AgileManager.DataStorage.Extensions;
using MeControla.AgileManager.TestingTools.FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Extensions
{
    public class DatabaseConfigurationExtensionTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 4;

        [Fact(DisplayName = "[DatabaseConfigurationExtension.AddDatabaseServices] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddDatabaseServices(string.Empty));

        [Fact(DisplayName = "[DatabaseConfigurationExtension.AddDatabaseServices] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddDatabaseServices(string.Empty);

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.ShouldAsSingleton<DbContextOptions>();
            serviceCollection.ShouldAsSingleton<DbAppContext>();
            serviceCollection.ShouldAsSingleton<IDbAppContext, DbAppContext>();
        }
    }
}