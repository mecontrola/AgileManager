using FluentAssertions;
using MeControla.AgileManager.Updater.Core.Exceptions;
using MeControla.AgileManager.Updater.Core.Tests.Mocks;
using MeControla.AgileManager.Updater.Core.Tests.Mocks.Integrations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Updater.Core.Tests.Integrations.Github
{
    public class GithubIntegrationTests : BaseGithubApiTests
    {
        private readonly GithubIntegrationMock service;

        public GithubIntegrationTests()
            : base()
        {
            ConfigureExceptionApi();
            ConfigureReleasesError();

            service = new GithubIntegrationMock(GetConfiguration());
        }

        [Fact(DisplayName = "[BaseGithubIntegration.GetResponse] Deve gerar a exceção GithubException quando o status da requisição retornada for 403.")]
        public async Task DeveGerarJiraForbiddenExceptionQuandoStatus403()
        {
            var action = () => service.Execute(HttpStatusCode.Forbidden, GetCancellationToken());
            await action.Should().ThrowAsync<GithubException>();
        }

        [Fact(DisplayName = "[BaseGithubIntegration.GetResponse] Deve gerar a exceção JiraException quando o status da requisição retornada for 408.")]
        public async Task DeveGerarJiraExceptionQuandoStatus409()
        {
            var action = () => service.Execute(HttpStatusCode.RequestTimeout, GetCancellationToken());
            await action.Should().ThrowAsync<GithubException>();
        }

        [Fact(DisplayName = "[BaseGithubIntegration.GetResponse] Deve gerar a exceção JiraException iniciado de texto quando ocorrer erro ao deserializar resposta.")]
        public async Task DeveGerarJiraExceptionQuandoErroDeserializacao()
        {
            var action = () => service.ExecuteJsonError(GetCancellationToken());
            await action.Should().ThrowAsync<GithubException>().Where(x => x.Message.StartsWith(DataMock.ERROR_JSON_EXCEPTION_START_WITH));
        }
    }
}