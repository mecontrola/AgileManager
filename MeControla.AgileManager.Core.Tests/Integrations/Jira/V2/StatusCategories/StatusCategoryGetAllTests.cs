using FluentAssertions;
using MeControla.AgileManager.Core.Integrations.Jira.V2.StatusCategories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using StatusCategoriesEnum = MeControla.AgileManager.Data.Enums.StatusCategories;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira.V2.StatusCategories
{
    public class StatusCategoryGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_STATUS_CATEGORIES = 4;

        private readonly IStatusCategoryGetAll statusGetAll;

        public StatusCategoryGetAllTests()
            : base()
        {
            ConfigureStatusCategoryGetAll();

            statusGetAll = new StatusCategoryGetAll(GetSettings());
        }

        [Fact(DisplayName = "[StatusCategoryGetAll.Execute] Deve recuperar a lista de todos os status category cadastrados no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await statusGetAll.Execute(GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_STATUS_CATEGORIES);
            response.Any(x => x.Name.Equals(StatusCategoriesEnum.Done.ToString())).Should().BeTrue();
        }
    }
}