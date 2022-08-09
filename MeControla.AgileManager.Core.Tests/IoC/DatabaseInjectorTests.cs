using FluentAssertions;
using MeControla.AgileManager.TestingTools.FluentAssertions.Extensions;
using MeControla.AgileManager.DataStorage.IoC;
using MeControla.AgileManager.DataStorage.Repositories;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.IoC
{
    public class DatabaseInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 10;

        [Fact(DisplayName = "[DatabaseInjector.AddBusiness] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddRepositories());

        [Fact(DisplayName = "[DatabaseInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddRepositories();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.ShouldAsTransient<IIssueEpicRepository, IssueEpicRepository>();
            serviceCollection.ShouldAsTransient<IIssueRepository, IssueRepository>();
            serviceCollection.ShouldAsTransient<IIssueImpedimentRepository, IssueImpedimentRepository>();
            serviceCollection.ShouldAsTransient<IIssueTypeRepository, IssueTypeRepository>();
            serviceCollection.ShouldAsTransient<IIssueStatusHistoryRepository, IssueStatusHistoryRepository>();
            serviceCollection.ShouldAsTransient<IProjectRepository, ProjectRepository>();
            serviceCollection.ShouldAsTransient<IProjectCategoryRepository, ProjectCategoryRepository>();
            serviceCollection.ShouldAsTransient<IQuarterRepository, QuarterRepository>();
            serviceCollection.ShouldAsTransient<IStatusRepository, StatusRepository>();
            serviceCollection.ShouldAsTransient<IStatusCategoryRepository, StatusCategoryRepository>();
        }
    }
}