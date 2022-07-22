using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Stefanini.Core.TestingTools.FluentAssertions.Extensions;
using Stefanini.ViaReport.Core.Tests.IoC;
using Stefanini.ViaReport.DataStorage;
using Stefanini.ViaReport.DataStorage.Extensions;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Extensions
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