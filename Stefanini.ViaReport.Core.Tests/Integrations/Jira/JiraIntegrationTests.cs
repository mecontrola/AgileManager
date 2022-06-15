using FluentAssertions;
using Stefanini.ViaReport.Core.Exceptions;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Integrations.Jira;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira
{
    public class JiraIntegrationTests : BaseJiraApiTests
    {
        private readonly JiraIntegrationMock service;

        public JiraIntegrationTests()
            : base()
        {
            ConfigureExceptionApi();

            service = new JiraIntegrationMock(GetConfiguration());
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraAuthenticationException quando o status da requisição retornada for 401.")]
        public async Task DeveGerarJiraAuthenticationExceptionQuandoStatus401()
        {
            var action = () => service.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, HttpStatusCode.Unauthorized, GetCancellationToken());
            await action.Should().ThrowAsync<JiraAuthenticationException>();
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraForbiddenException quando o status da requisição retornada for 403.")]
        public async Task DeveGerarJiraForbiddenExceptionQuandoStatus403()
        {
            var action = () => service.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, HttpStatusCode.Forbidden, GetCancellationToken());
            await action.Should().ThrowAsync<JiraForbiddenException>();
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraException quando o status da requisição retornada for 408.")]
        public async Task DeveGerarJiraExceptionQuandoStatus409()
        {
            var action = () => service.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, HttpStatusCode.RequestTimeout, GetCancellationToken());
            await action.Should().ThrowAsync<JiraException>();
        }
    }
}