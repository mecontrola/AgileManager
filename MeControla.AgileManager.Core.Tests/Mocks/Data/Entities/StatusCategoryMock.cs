using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Entities
{
    public class StatusCategoryMock
    {
        public static StatusCategory CreateToDo()
            => new()
            {
                Key = (long)StatusCategories.ToDo,
                Name = DataMock.TEXT_STATUS_CATEGORY_TO_DO
            };

        public static StatusCategory CreateInProgress()
            => new()
            {
                Key = (long)StatusCategories.InProgress,
                Name = DataMock.TEXT_STATUS_CATEGORY_IN_PROGRESS
            };

        public static StatusCategory CreateDone()
            => new()
            {
                Key = (long)StatusCategories.Done,
                Name = DataMock.TEXT_STATUS_CATEGORY_DONE
            };

        public static StatusCategory CreateNoCategory()
            => new()
            {
                Key = (int)StatusCategories.NoCategory,
                Name = DataMock.TEXT_STATUS_CATEGORY_NO_CATEGORY
            };

        public static IList<StatusCategory> CreateList()
            => new List<StatusCategory>
            {
                CreateNoCategory(),
                CreateToDo(),
                CreateInProgress(),
                CreateDone(),
            };
    }
}