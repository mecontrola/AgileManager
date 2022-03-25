using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
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