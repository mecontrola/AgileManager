using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class ChangelogDtoMock
    {
        public static ChangelogDto CreateEmpty()
            => new()
            {
                Histories = new List<HistoryDto>(),
            };
    }
}