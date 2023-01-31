using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Data.Dtos
{
    public class IssueTypeDtoMock
    {
        public static IssueTypeDto CreateTask()
            => new()
            {
                Id = $"{(long)DataMock.INT_ID_2}",
                Name = DataMock.ISSUETYPE_NAME_TASK,
            };

        public static IssueTypeDto CreateSubTask()
            => new()
            {
                Id = $"{(long)DataMock.INT_ID_3}",
                Name = DataMock.ISSUETYPE_NAME_SUBTASk,
            };

        public static IssueTypeDto CreateStory()
            => new()
            {
                Id = $"{(long)DataMock.INT_ID_5}",
                Name = DataMock.ISSUETYPE_NAME_STORY,
            };

        public static IssueTypeDto CreateBug()
            => new()
            {
                Id = $"{(long)DataMock.INT_ID_1}",
                Name = DataMock.ISSUETYPE_NAME_BUG,
            };

        public static IssueTypeDto CreateEpic()
            => new()
            {
                Id = $"{(long)DataMock.INT_ID_4}",
                Name = DataMock.ISSUETYPE_NAME_EPIC,
            };

        public static IssueTypeDto CreateTechnicalDebt()
            => new()
            {
                Id = $"{(long)DataMock.INT_ID_8}",
                Name = DataMock.ISSUETYPE_NAME_TECHNICALDEBT,
            };

        public static IssueTypeDto CreateTechnicalImprovement()
            => new()
            {
                Id = $"{(long)DataMock.INT_ID_9}",
                Name = DataMock.ISSUETYPE_NAME_TECHNICALIMPROVEMENT,
            };

        public static IList<IssueTypeDto> CreateList()
            => new List<IssueTypeDto>()
            {
                CreateTask(),
                CreateSubTask(),
                CreateStory(),
                CreateBug(),
                CreateEpic(),
                CreateTechnicalDebt(),
                CreateTechnicalImprovement(),
            };
    }
}