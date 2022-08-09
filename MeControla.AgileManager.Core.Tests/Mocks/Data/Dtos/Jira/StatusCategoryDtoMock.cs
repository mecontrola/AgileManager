using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Enums;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class StatusCategoryDtoMock
    {
        public static StatusCategoryDto CreateToDo()
            => new()
            {
                Id = (int)StatusCategories.ToDo,
                Name = DataMock.TEXT_STATUS_CATEGORY_TO_DO,
                Self = "https://jira.viavarejo.com.br/rest/api/2/statuscategory/2",
                Key = "new",
                ColorName = "blue-gray",
            };

        public static StatusCategoryDto CreateInProgress()
            => new()
            {
                Id = (int)StatusCategories.InProgress,
                Name = DataMock.TEXT_STATUS_CATEGORY_IN_PROGRESS,
                Self = "https://jira.viavarejo.com.br/rest/api/2/statuscategory/4",
                Key = "indeterminate",
                ColorName = "yellow",
            };

        public static StatusCategoryDto CreateDone()
            => new()
            {
                Id = (int)StatusCategories.Done,
                Name = DataMock.TEXT_STATUS_CATEGORY_DONE,
                Self = "https://jira.viavarejo.com.br/rest/api/2/statuscategory/3",
                Key = "done",
                ColorName = "green",
            };

        public static StatusCategoryDto CreateNoCategory()
            => new()
            {
                Id = (int)StatusCategories.NoCategory,
                Name = DataMock.TEXT_STATUS_CATEGORY_NO_CATEGORY,
                Self = "https://jira.viavarejo.com.br/rest/api/2/statuscategory/1",
                Key = "undefined",
                ColorName = "medium-gray",
            };

        public static IList<StatusCategoryDto> CreateList()
            => new List<StatusCategoryDto>
            {
                CreateNoCategory(),
                CreateToDo(),
                CreateInProgress(),
                CreateDone(),
            };
    }
}