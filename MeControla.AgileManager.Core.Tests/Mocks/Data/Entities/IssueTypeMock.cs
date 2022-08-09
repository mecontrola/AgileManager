using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Entities
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

        public static IDictionary<string, long> CreateDictionary()
            => new Dictionary<string, long>
            {
                { $"{(long)IssueTypes.Bug}", DataMock.INT_ID_1 },
                { $"{(long)IssueTypes.Task}", DataMock.INT_ID_2 },
                { $"{(long)IssueTypes.Improvement}", DataMock.INT_ID_3 },
                { $"{(long)IssueTypes.SubTask}", DataMock.INT_ID_4 },
                { $"{(long)IssueTypes.Epic}", DataMock.INT_ID_5 },
                { $"{(long)IssueTypes.Story}", DataMock.INT_ID_6 },
                { $"{(long)IssueTypes.TechnicalDebt}", 7 },
            };
    }
}