using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class IssueTypeMock
    {
        public static IssueType CreateTask()
            => new()
            {
                Key = (long)IssueTypes.Task,
                Name = DataMock.ISSUETYPE_NAME_TASK,
            };

        public static IssueType CreateSubTask()
            => new()
            {
                Key = (long)IssueTypes.SubTask,
                Name = DataMock.ISSUETYPE_NAME_SUBTASk,
            };

        public static IssueType CreateStory()
            => new()
            {
                Key = (long)IssueTypes.Story,
                Name = DataMock.ISSUETYPE_NAME_STORY,
            };

        public static IssueType CreateBug()
            => new()
            {
                Key = (long)IssueTypes.Bug,
                Name = DataMock.ISSUETYPE_NAME_BUG,
            };

        public static IssueType CreateEpic()
            => new()
            {
                Key = (long)IssueTypes.Epic,
                Name = DataMock.ISSUETYPE_NAME_EPIC,
            };

        public static IssueType CreateTechnicalDebt()
            => new()
            {
                Key = (long)IssueTypes.TechnicalDebt,
                Name = DataMock.ISSUETYPE_NAME_TECHNICALDEBT,
            };

        public static IssueType CreateTechnicalImprovement()
            => new()
            {
                Key = (long)IssueTypes.Improvement,
                Name = DataMock.ISSUETYPE_NAME_TECHNICALIMPROVEMENT,
            };

        public static IList<IssueType> CreateList()
            => new List<IssueType>()
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