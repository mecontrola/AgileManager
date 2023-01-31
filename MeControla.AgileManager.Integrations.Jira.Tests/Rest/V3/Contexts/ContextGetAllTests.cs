using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Contexts;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.Contexts
{
    public class ContextGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_CONTEXTS = 1;

        private readonly IContextGetAll contextGetAll;

        public ContextGetAllTests()
            : base()
        {
            ConfigureContextGetAll();

            contextGetAll = new ContextGetAll(GetConfiguration());
        }

        [Fact(DisplayName = "[ContextGetAll.Execute] Deve recuperar a issue especificada cadastrada no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await contextGetAll.Execute(DataMock.FIELD_ID_CLASSES_OF_SERVICE, GetCancellationToken());

            response.Should().NotBeNull();
            response.Values.Should().HaveCount(TOTAL_CONTEXTS);
            response.Values.Any(x => x.Name.Equals(DataMock.CONTEXT_NAME_DEFAULT)).Should().BeTrue();
        }
    }
}