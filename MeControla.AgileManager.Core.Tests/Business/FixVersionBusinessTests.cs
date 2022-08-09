using FluentAssertions;
using MeControla.AgileManager.Core.Business;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Mappers;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using MeControla.AgileManager.Core.Tests.Mocks.Services;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.TestingTools;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Business
{
    public class FixVersionBusinessTests : BaseAsyncMethods
    {
        private readonly IFixVersionBusiness business;

        public FixVersionBusinessTests()
        {
            var issuesNotFixVersionService = IssuesNotFixVersionServiceMock.Create();
            var issueGet = IssueGetMock.Create();
            var issueDtoToIssueInfoDtoMapper = new JiraIssueDtoToIssueDtoMapper(new MountJiraUrlHelper());

            business = new FixVersionBusiness(issuesNotFixVersionService, issueDtoToIssueInfoDtoMapper, issueGet);
        }

        [Fact(DisplayName = "[FixVersionBusiness.GetListIssuesNoFixVersion]")]
        public async void Deve()
        {
            var expected = IssueDtoMock.CreateDoneList();
            var actual = await business.GetListIssuesNoFixVersion(DataMock.TEXT_SEARCH_PROJECT, GetCancellationToken());

            for (int i = 0, l = actual.Count; i < l; i++)
                AssertIssue(actual[i], expected[i]);
        }

        private static void AssertIssue(IssueDto actual, IssueDto expected)
        {
            actual.Key.Should().BeEquivalentTo(expected.Key);
            actual.Description.Should().BeEquivalentTo(expected.Description);
            actual.Status.Should().BeEquivalentTo(expected.Status);
            actual.Created.Date.Should().Be(expected.Created.Date);
            actual.Resolved.Value.Date.Should().Be(expected.Resolved.Value.Date);
            actual.Link.Should().BeEquivalentTo(expected.Link);
        }
    }
}