using FluentAssertions;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Stefanini.ViaReport.Core.Tests.Mocks.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Business
{
    public class FixVersionBusinessTests : BaseAsyncMethods
    {
        private readonly IFixVersionBusiness business;

        public FixVersionBusinessTests()
        {
            var issuesNotFixVersionService = IssuesNotFixVersionServiceMock.Create();
            var issueGet = IssueGetMock.Create();
            var issueDtoToIssueInfoDtoMapper = new IssueDtoToIssueInfoDtoMapper();

            business = new FixVersionBusiness(issuesNotFixVersionService, issueDtoToIssueInfoDtoMapper, issueGet);
        }

        [Fact(DisplayName = "[FixVersionBusiness.GetListIssuesNoFixVersion]")]
        public async void Deve()
        {
            var expected = IssueInfoDtoMock.CreateDoneList();
            var actual = await business.GetListIssuesNoFixVersion(DataMock.VALUE_USERNAME,
                                                                  DataMock.VALUE_PASSWORD,
                                                                  DataMock.TEXT_SEARCH_PROJECT,
                                                                  GetCancellationToken());
            actual.Should().BeEquivalentTo(expected);
        }
    }
}