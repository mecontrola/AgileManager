using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Fields;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.Fields
{
    public class FieldGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_FIELDS = 83;

        private readonly IFieldGetAll fieldGetAll;

        public FieldGetAllTests()
            : base()
        {
            ConfigureFieldGetAll();

            fieldGetAll = new FieldGetAll(GetConfiguration());
        }

        [Fact(DisplayName = "[FieldGetAll.Execute] Deve recuperar a issue especificada cadastrada no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await fieldGetAll.Execute(GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_FIELDS);
            response.Any(x => x.Name.Equals(DataMock.FIELD_NAME_CLASSES_OF_SERVICE)).Should().BeTrue();
        }
    }
}