using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class SearchDtoMock
    {
        private const string SEARCH_RESULT_FILE_NAME = "search.post.all.json";

        public static SearchDto CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<SearchDto>(SEARCH_RESULT_FILE_NAME);
    }
}