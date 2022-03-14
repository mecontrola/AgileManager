using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class SearchDtoMock
    {
        private const string SEARCH_RESULT_ALL_FILE_NAME = "search.post.all.json";
        private const string SEARCH_RESULT_DONE_FILE_NAME = "search.post.done.json";

        public static SearchDto CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<SearchDto>(SEARCH_RESULT_ALL_FILE_NAME);

        public static SearchDto CreateIssueDoneList()
            => ApiUtilMockHelper.LoadJsonMock<SearchDto>(SEARCH_RESULT_DONE_FILE_NAME);
    }
}