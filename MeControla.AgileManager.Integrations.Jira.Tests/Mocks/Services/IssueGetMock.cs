using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Data.Dtos;
using NSubstitute;
using System.Threading;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Services
{
    public class IssueGetMock
    {
        public static IIssueGet Create()
        {
            var mock = Substitute.For<IIssueGet>();

            mock.Execute(Arg.Any<string>(),
                         Arg.Any<CancellationToken>())
                .Returns(callContext =>
                {
                    var key = callContext.ArgAt<string>(0);
                    return IssueDtoMock.CreateIssueByJson(key);
                });

            return mock;
        }
    }
}