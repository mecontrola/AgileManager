using FluentAssertions;
using Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira.V1.Auth
{
    public class SessionGetTests : BaseJiraApiTests
    {
        private readonly ISessionGet service;

        public SessionGetTests()
            : base()
        {
            ConfigureSessionGet();

            service = new SessionGet(GetConfiguration());
        }

        [Fact(DisplayName = "[SessionGet.Execute] Deve retornar as informações da sessão do usuário autenciado no Jira.")]
        public async Task DeveRetornarDadosSessaoUsuarioJira()
        {
            var response = await service.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, GetCancellationToken());

            response.Should().NotBeNull();
        }
    }
}