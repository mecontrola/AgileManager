using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Data.Dtos
{
    public class StatusCategoryDtoMock
    {
        public static StatusCategoryDto CreateToDo()
            => new()
            {
                Id = DataMock.INT_ID_2,
                Name = DataMock.TEXT_STATUS_CATEGORY_TO_DO,
                Self = "https://jira.viavarejo.com.br/rest/api/2/statuscategory/2",
                Key = "new",
                ColorName = "blue-gray",
            };

        public static StatusCategoryDto CreateInProgress()
            => new()
            {
                Id = DataMock.INT_ID_4,
                Name = DataMock.TEXT_STATUS_CATEGORY_IN_PROGRESS,
                Self = "https://jira.viavarejo.com.br/rest/api/2/statuscategory/4",
                Key = "indeterminate",
                ColorName = "yellow",
            };

        public static StatusCategoryDto CreateDone()
            => new()
            {
                Id = DataMock.INT_ID_3,
                Name = DataMock.TEXT_STATUS_CATEGORY_DONE,
                Self = "https://jira.viavarejo.com.br/rest/api/2/statuscategory/3",
                Key = "done",
                ColorName = "green",
            };

        public static StatusCategoryDto CreateNoCategory()
            => new()
            {
                Id = DataMock.INT_ID_1,
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