using NSubstitute;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class IssueGetMock
    {
        public static IIssueGet Create()
        {
            var issueGet = Substitute.For<IIssueGet>();

            foreach (var key in ApiUtilMockHelper.GetKeyIssues())
                Configure(issueGet, key);

            return issueGet;
        }

        private static void Configure(IIssueGet obj, string key)
            => obj.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                           Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                           Arg.Is<string>(x => x.Equals(key)),
                           Arg.Any<CancellationToken>()).Returns(IssueDtoMock.CreateIssueByJson(key));
    }
}