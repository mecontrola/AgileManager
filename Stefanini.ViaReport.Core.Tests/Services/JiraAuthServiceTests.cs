using FluentAssertions;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class JiraAuthServiceTests : BaseAsyncMethods
    {
        [Theory(DisplayName = "[JiraAuthService.IsAuthenticationOk] Deve verificar a autenticação do usuário.")]
        [MemberData(nameof(GetEnumeratorCases))]
        public async Task DeveVerificarAuthenticacao(IJiraAuthService service, bool expected)
        {
            var actual = await service.IsAuthenticationOk(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, GetCancellationToken());

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetEnumeratorCases()
        {
            yield return new object[] { CreateServiceNormal(), true };
            yield return new object[] { CreateServiceWithJiraAuthenticationException(), false };
            yield return new object[] { CreateServiceWithJiraForbiddenException(), false };
        }

        private static IJiraAuthService CreateServiceNormal()
            => new JiraAuthService(SessionGetMock.Create());

        private static IJiraAuthService CreateServiceWithJiraAuthenticationException()
            => new JiraAuthService(SessionGetMock.CreateWithJiraAuthenticationException());

        private static IJiraAuthService CreateServiceWithJiraForbiddenException()
            => new JiraAuthService(SessionGetMock.CreateWithJiraForbiddenException());
    }
}