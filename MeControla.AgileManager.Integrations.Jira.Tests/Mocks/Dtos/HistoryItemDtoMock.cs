using MeControla.AgileManager.Integrations.Jira.Data.Dtos;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Data.Dtos
{
    public class HistoryItemDtoMock
    {
        public static HistoryItemDto CreateStatus()
            => new()
            {
                Field = DataMock.HISTORYITEM_FIELD_STATUS,
                Fieldtype = DataMock.HISTORYITEM_FIELDTYPE_JIRA,
                From = $"{DataMock.INT_STATUS_TO_TEST}",
                FromString = DataMock.TEXT_STATUS_TO_TEST,
                To = $"{DataMock.INT_STATUS_IN_TEST}",
                ToString = DataMock.TEXT_STATUS_IN_TEST
            };

        public static HistoryItemDto CreateAssignee()
            => new()
            {
                Field = DataMock.HISTORYITEM_FIELD_ASSIGNEE,
                Fieldtype = DataMock.HISTORYITEM_FIELDTYPE_JIRA,
                From = "JIRAUSER38098",
                FromString = "GEOVANNI OLIVEIRA DE JESUS",
                To = "JIRAUSER37782",
                ToString = "ICARO DOS SANTOS SILVA"
            };

        public static HistoryItemDto CreateImpediment()
            => new()
            {
                Field = DataMock.HISTORYITEM_FIELD_FLAGGED,
                Fieldtype = DataMock.HISTORYITEM_FIELDTYPE_CUSTOM,
                To = "[10000]",
                ToString = "Impediment"
            };

        public static HistoryItemDto CreateImpedimentClose()
            => new()
            {
                Field = DataMock.HISTORYITEM_FIELD_FLAGGED,
                Fieldtype = DataMock.HISTORYITEM_FIELDTYPE_CUSTOM,
                From = "[10000]",
                FromString = "Impediment"
            };
    }
}