using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class ProjectMock
    {
        public static Project CreateSearch()
        {
            var entity = CreateSearchFromJira();
            entity.Id = DataMock.INT_ID_1;
            entity.ProjectCategoryId = DataMock.INT_ID_1;
            entity.ProjectCategory = ProjectCategoryMock.CreateAplicativos();
            return entity;
        }

        public static Project CreateSearchFromJira()
            => new()
            {
                Key = DataMock.INT_SEARCH_PROJECT_KEY,
                Name = DataMock.TEXT_SEARCH_PROJECT,
            };

        public static Project CreateSearchWithSelectedTrue()
        {
            var entity = CreateSearch();
            entity.Selected = true;
            return entity;
        }

        public static Project CreateLoyalty()
        {
            var entity = CreateLoyaltyFromJira();
            entity.Id = DataMock.INT_ID_2;
            entity.ProjectCategoryId = DataMock.INT_ID_4;
            entity.ProjectCategory = ProjectCategoryMock.CreateFidelizacao();
            return entity;
        }

        public static Project CreateLoyaltyFromJira()
            => new()
            {
                Key = DataMock.INT_LOYALTY_PROJECT_KEY,
                Name = DataMock.TEXT_LOYALTY_PROJECT,
            };

        public static Project CreateLoyaltyWithSelectedTrue()
        {
            var entity = CreateLoyalty();
            entity.Selected = true;
            return entity;
        }

        public static Project CreateCoreApps()
            => new()
            {
                Id = DataMock.INT_ID_3,
                Key = DataMock.INT_COREAPPS_PROJECT_KEY,
                Name = DataMock.TEXT_COREAPPS_PROJECT_KEY,
                Selected = false,
                ProjectCategoryId = DataMock.INT_ID_1,
                ProjectCategory = ProjectCategoryMock.CreateAplicativos()
            };

        public static Project CreateChoose()
            => new()
            {
                Id = DataMock.INT_ID_4,
                Key = DataMock.INT_CHOOSE_PROJECT_KEY,
                Name = DataMock.TEXT_CHOOSE_PROJECT_KEY,
                Selected = false,
                ProjectCategoryId = DataMock.INT_ID_1,
                ProjectCategory = ProjectCategoryMock.CreateAplicativos()
            };

        public static IList<Project> CreateList()
            => new List<Project>
            {
                CreateSearch(),
                CreateLoyalty(),
                CreateCoreApps(),
                CreateChoose(),
            };

        public static IList<Project> CreateListFromJira()
            => new List<Project>
            {
                CreateSearchFromJira(),
                CreateLoyaltyFromJira(),
            };
    }
}