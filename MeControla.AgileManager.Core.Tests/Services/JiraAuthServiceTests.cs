using FluentAssertions;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Services;
using MeControla.AgileManager.TestingTools;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class JiraAuthServiceTests : BaseAsyncMethods
    {
        [Theory(DisplayName = "[JiraAuthService.IsAuthenticationOk] Deve verificar a autenticação do usuário.")]
        [MemberData(nameof(GetEnumeratorCases))]
        public async Task DeveVerificarAuthenticacao(IJiraAuthService service, bool expected)
        {
            var actual = await service.IsAuthenticationOk(GetCancellationToken());

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