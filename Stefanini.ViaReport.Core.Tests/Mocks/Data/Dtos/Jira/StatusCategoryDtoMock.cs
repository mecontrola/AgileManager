using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
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

        public static IList<StatusCategoryDto> CreateList()
            => new List<StatusCategoryDto>
            {
                CreateToDo(),
                CreateInProgress(),
                CreateDone(),
            };
    }
}