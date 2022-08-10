using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos
{
    public class ProjectDtoMock
    {
        public static ProjectDto CreateSearch()
            => new()
            {
                Id = DataMock.INT_ID_1,
                Name = DataMock.TEXT_SEARCH_PROJECT,
                Category = ProjectCategoryDtoMock.CreateAplicativos()
            };

        public static ProjectDto CreateSearchWithSelectedTrue()
        {
            var dto = CreateSearch();
            dto.Selected = true;
            return dto;
        }

        public static ProjectDto CreateLoyalty()
            => new()
            {
                Id = DataMock.INT_ID_2,
                Name = DataMock.TEXT_LOYALTY_PROJECT,
                Category = ProjectCategoryDtoMock.CreateFidelizacao()
            };

        public static ProjectDto CreateLoyaltyWithSelectedTrue()
        {
            var dto = CreateLoyalty();
            dto.Selected = true;
            return dto;
        }

        public static IList<ProjectDto> CreateListSelected()
            => new List<ProjectDto>
            {
                CreateSearchWithSelectedTrue(),
                CreateLoyaltyWithSelectedTrue()
            };

        public static ProjectDto CreateCoreApps()
            => new()
            {
                Id = DataMock.INT_ID_3,
                Name = DataMock.TEXT_COREAPPS_PROJECT_KEY,
                Category = ProjectCategoryDtoMock.CreateAplicativos()
            };

        public static ProjectDto CreateChoose()
            => new()
            {
                Id = DataMock.INT_ID_4,
                Name = DataMock.TEXT_CHOOSE_PROJECT_KEY,
                Category = ProjectCategoryDtoMock.CreateAplicativos()
            };

        public static IList<ProjectDto> CreateList()
            => new List<ProjectDto>
            {
                CreateSearch(),
                CreateLoyalty(),
                CreateCoreApps(),
                CreateChoose()
            };

        public static IList<ProjectDto> CreateListWithSearchLoyaltySelected()
            => new List<ProjectDto>
            {
                CreateSearchWithSelectedTrue(),
                CreateLoyaltyWithSelectedTrue(),
                CreateCoreApps(),
                CreateChoose()
            };
    }
}