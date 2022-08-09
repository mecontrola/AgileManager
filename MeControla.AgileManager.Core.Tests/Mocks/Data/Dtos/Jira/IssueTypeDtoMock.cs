using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Enums;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class IssueTypeDtoMock
    {
        public static IssueTypeDto CreateTask()
            => new()
            {
                Id = $"{(long)IssueTypes.Task}",
                Name = DataMock.ISSUETYPE_NAME_TASK,
            };

        public static IssueTypeDto CreateSubTask()
            => new()
            {
                Id = $"{(long)IssueTypes.SubTask}",
                Name = DataMock.ISSUETYPE_NAME_SUBTASk,
            };

        public static IssueTypeDto CreateStory()
            => new()
            {
                Id = $"{(long)IssueTypes.Story}",
                Name = DataMock.ISSUETYPE_NAME_STORY,
            };

        public static IssueTypeDto CreateBug()
            => new()
            {
                Id = $"{(long)IssueTypes.Bug}",
                Name = DataMock.ISSUETYPE_NAME_BUG,
            };

        public static IssueTypeDto CreateEpic()
            => new()
            {
                Id = $"{(long)IssueTypes.Epic}",
                Name = DataMock.ISSUETYPE_NAME_EPIC,
            };

        public static IssueTypeDto CreateTechnicalDebt()
            => new()
            {
                Id = $"{(long)IssueTypes.TechnicalDebt}",
                Name = DataMock.ISSUETYPE_NAME_TECHNICALDEBT,
            };

        public static IssueTypeDto CreateTechnicalImprovement()
            => new()
            {
                Id = $"{(long)IssueTypes.Improvement}",
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