using FluentAssertions;
using MeControla.AgileManager.Core.Integrations.Jira.V1.Auth;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira.V1.Auth
{
    public class SessionGetTests : BaseJiraApiTests
    {
        private readonly ISessionGet service;

        public SessionGetTests()
            : base()
        {
            ConfigureSessionGet();

            service = new SessionGet(GetSettings());
        }

        [Fact(DisplayName = "[SessionGet.Execute] Deve retornar as informações da sessão do usuário autenciado no Jira.")]
        public async Task DeveRetornarDadosSessaoUsuarioJira()
        {
            var response = await service.Execute(GetCancellationToken());

            response.Should().NotBeNull();
        }
    }
}