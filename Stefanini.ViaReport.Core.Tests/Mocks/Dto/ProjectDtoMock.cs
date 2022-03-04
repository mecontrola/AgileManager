using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class ProjectDtoMock
    {
        private const string PROJECT_RESULT_FILE_NAME = "project.get.all.json";

        public static ProjectDto CreateSearch()
            => new()
            {
                Name = DataMock.TEXT_SEARCH_PROJECT
            };

        public static ProjectDto[] CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<ProjectDto[]>(PROJECT_RESULT_FILE_NAME);
    }
}