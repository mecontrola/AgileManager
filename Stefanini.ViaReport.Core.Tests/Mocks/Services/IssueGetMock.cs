using NSubstitute;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class IssueGetMock
    {
        public static IIssueGet Create()
        {
            var mock = Substitute.For<IIssueGet>();

            mock.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                           Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                           Arg.Any<string>(),
                           Arg.Any<CancellationToken>())
                  .Returns(callContext =>
                  {
                      var key = callContext.ArgAt<string>(2);
                      return IssueDtoMock.CreateIssueByJson(key);
                  });

            return mock;
        }
    }
}