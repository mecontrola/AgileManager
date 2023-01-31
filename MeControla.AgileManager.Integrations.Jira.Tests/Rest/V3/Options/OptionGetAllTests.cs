using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Options;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.Options
{
    public class OptionGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_CONTEXTS = 4;

        private readonly IOptionGetAll optionGetAll;

        public OptionGetAllTests()
            : base()
        {
            ConfigureOptionGetAll();

            optionGetAll = new OptionGetAll(GetConfiguration());
        }

        [Fact(DisplayName = "[OptionGetAll.Execute] Deve recuperar a issue especificada cadastrada no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await optionGetAll.Execute(DataMock.FIELD_ID_CLASSES_OF_SERVICE,
                                                      DataMock.CONTEXT_ID_DEFAULT,
                                                      GetCancellationToken());

            response.Should().NotBeNull();
            response.Values.Should().HaveCount(TOTAL_CONTEXTS);
            response.Values.Any(x => x.Value.Equals(DataMock.CLASSES_OF_SERVICE_EXPEDITE)).Should().BeTrue();
        }
    }
}