using MeControla.AgileManager.Core.Tests.TestUtils.Helpers;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class SearchDtoMock
    {
        private const string SEARCH_RESULT_DONE_FILE_NAME = "search.post.done.json";

        public static SearchDto CreateEmpty()
            => new()
            {
                StartAt = 0,
                MaxResults = 0,
                Total = 0,
                Issues = Array.Empty<IssueDto>()
            };

        public static SearchDto CreatePart1To5From10()
            => new()
            {
                StartAt = 0,
                MaxResults = 5,
                Total = 10,
                Issues = IssueDtoMock.CreatePart1To5From10()
            };

        public static SearchDto CreatePart6To10From10()
            => new()
            {
                StartAt = 5,
                MaxResults = 5,
                Total = 10,
                Issues = IssueDtoMock.CreatePart6To10From10()
            };

        public static SearchDto CreateIssueDoneList()
            => ApiUtilMockHelper.LoadJsonMock<SearchDto>(SEARCH_RESULT_DONE_FILE_NAME);
    }
}