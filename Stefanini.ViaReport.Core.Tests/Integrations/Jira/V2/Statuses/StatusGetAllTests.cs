using FluentAssertions;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira.V2.Statuses
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
            var response = await statusGetAll.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_STATUSES);
            response.Any(x => x.Name.Equals(DataMock.TEXT_STATUS_EM_DESENVOLVIMENTO)).Should().BeTrue();
        }
    }
}