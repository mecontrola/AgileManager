using MeControla.AgileManager.Core.Integrations.Jira.V2.Issues;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using NSubstitute;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
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