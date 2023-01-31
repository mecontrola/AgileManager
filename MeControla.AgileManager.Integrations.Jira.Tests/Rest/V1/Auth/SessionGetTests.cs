using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V1.Auth;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V1.Auth
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
            var response = await service.Execute(GetCancellationToken());

            response.Should().NotBeNull();
        }
    }
}