using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class IssueMock
    {
        public static Issue CreateIssue1()
            => new()
            {
                Key = DataMock.ISSUE_KEY_1,
                Summary = DataMock.ISSUE_DESCRIPTION_1,
            };

        public static Issue CreateIssue2()
            => new()
            {
                Key = DataMock.ISSUE_KEY_2,
                Summary = DataMock.ISSUE_DESCRIPTION_2,
                Incident = true
            };

        public static IList<Issue> CreateList()
            => new List<Issue>
            {
                CreateIssue1(),
                CreateIssue2()
            };
    }
}