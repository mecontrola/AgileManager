using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Data.Dtos
{
    public class ChangelogDtoMock
    {
        public static ChangelogDto CreateEmpty()
            => new()
            {
                Histories = Array.Empty<HistoryDto>(),
            };

        public static ChangelogDto CreateList()
            => new()
            {
                Histories = new List<HistoryDto>
                {
                    HistoryDtoMock.CreateStatus(),
                    HistoryDtoMock.CreateImpediment()
                },
            };
    }
}