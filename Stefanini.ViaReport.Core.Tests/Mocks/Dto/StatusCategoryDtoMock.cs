using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Enums;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class StatusCategoryDtoMock
    {
        public static StatusCategoryDto CreateToDo()
            => new()
            {
                Id = (int)StatusCategories.ToDo,
                Name = DataMock.TEXT_STATUS_CATEGORY_TO_DO
            };

        public static StatusCategoryDto CreateInProgress()
            => new()
            {
                Id = (int)StatusCategories.InProgress,
                Name = DataMock.TEXT_STATUS_CATEGORY_IN_PROGRESS
            };

        public static StatusCategoryDto CreateDone()
            => new()
            {
                Id = (int)StatusCategories.Done,
                Name = DataMock.TEXT_STATUS_CATEGORY_DONE
            };
    }
}