using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Statuses;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.Statuses
{
    public class StatusGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_STATUSES = 503;

        private readonly IStatusGetAll statusGetAll;

        public StatusGetAllTests()
            : base()
        {
            ConfigureStatusGetAll();

            statusGetAll = new StatusGetAll(GetConfiguration());
        }

        [Fact(DisplayName = "[StatusGetAll.Execute] Deve recuperar a lista de todos os status cadastrados no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await statusGetAll.Execute(GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_STATUSES);
            response.Any(x => x.Name.Equals(DataMock.TEXT_STATUS_EM_DESENVOLVIMENTO)).Should().BeTrue();
        }
    }
}