using FluentAssertions;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.StatusCategories;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using StatusCategoriesEnum = Stefanini.ViaReport.Core.Data.Enums.StatusCategories;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira.V2.StatusCategories
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
            var response = await statusGetAll.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_STATUS_CATEGORIES);
            response.Any(x => x.Name.Equals(StatusCategoriesEnum.Done.ToString())).Should().BeTrue();
        }
    }
}