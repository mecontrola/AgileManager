using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Stefanini.ViaReport.Data.Parameters;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Parameters
{
    public class IssueSynchronizerParamMock
    {
        public static IssueSynchronizerParam Create()
            => new()
            {
                IssueDto = IssueDtoMock.CreateAllFilled(),
                ProjectId = DataMock.INT_ID_1,
                Statuses = StatusMock.CreateDictionary(),
                IssueTypes = IssueTypeMock.CreateDictionary()
            };
    }
}