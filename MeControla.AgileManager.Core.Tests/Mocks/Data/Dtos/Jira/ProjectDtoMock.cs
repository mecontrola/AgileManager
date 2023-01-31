using MeControla.AgileManager.Core.Tests.TestUtils.Helpers;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class ProjectDtoMock
    {
        private const string PROJECT_RESULT_FILE_NAME = "project.get.all.json";

        public static ProjectDto CreateSearch()
            => new()
            {
                Id = DataMock.INT_SEARCH_PROJECT_KEY.ToString(),
                Name = DataMock.TEXT_SEARCH_PROJECT,
                ProjectCategory = ProjectCategoryDtoMock.CreateAplicativos()
            };

        public static ProjectDto CreateLoyalty()
            => new()
            {
                Id = DataMock.INT_LOYALTY_PROJECT_KEY.ToString(),
                Name = DataMock.TEXT_LOYALTY_PROJECT,
                ProjectCategory = ProjectCategoryDtoMock.CreateFidelizacao()
            };

        public static ProjectDto CreateCoreApps()
            => new()
            {
                Id = DataMock.INT_COREAPPS_PROJECT_KEY.ToString(),
                Name = DataMock.TEXT_COREAPPS_PROJECT_KEY,
                ProjectCategory = ProjectCategoryDtoMock.CreateAplicativos()
            };

        public static IList<ProjectDto> CreateList()
            => new List<ProjectDto>
            {
                CreateSearch(),
                CreateLoyalty(),
            };

        public static ProjectDto[] CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<ProjectDto[]>(PROJECT_RESULT_FILE_NAME);
    }
}