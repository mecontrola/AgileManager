using Stefanini.ViaReport.Data.Dtos.Jira;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class HistoryDtoMock
    {
        public static HistoryDto CreateStatus()
            => new()
            {
                Id = DataMock.HISTORYITEM_ID,
                Author = UserDtoMock.Create(),
                Created = DateTime.Parse("2022-05-12T16:12:00.063-0300"),
                Items = new List<HistoryItemDto>
                {
                    HistoryItemDtoMock.CreateStatus(),
                    HistoryItemDtoMock.CreateAssignee()
                }
            };

        public static HistoryDto CreateImpediment()
            => new()
            {
                Id = DataMock.HISTORYITEM_ID,
                Author = UserDtoMock.Create(),
                Created = DateTime.Parse("2022-05-13T13:54:04.703-0300"),
                Items = new List<HistoryItemDto>
                {
                    HistoryItemDtoMock.CreateImpediment()
                }
            };
    }
}