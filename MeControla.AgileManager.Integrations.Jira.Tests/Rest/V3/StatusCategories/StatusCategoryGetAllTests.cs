using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.StatusCategories;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.StatusCategories
{
    public class StatusCategoryGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_STATUS_CATEGORIES = 4;

        private readonly IStatusCategoryGetAll statusGetAll;

        public StatusCategoryGetAllTests()
            : base()
        {
            ConfigureStatusCategoryGetAll();

            statusGetAll = new StatusCategoryGetAll(GetConfiguration());
        }

        [Fact(DisplayName = "[StatusCategoryGetAll.Execute] Deve recuperar a lista de todos os status category cadastrados no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await statusGetAll.Execute(GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_STATUS_CATEGORIES);
            response.Any(x => x.Name.Equals(DataMock.TEXT_STATUS_CATEGORY_DONE)).Should().BeTrue();
        }
    }
}