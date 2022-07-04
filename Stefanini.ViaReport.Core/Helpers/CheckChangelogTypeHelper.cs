using Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class CheckChangelogTypeHelper : ICheckChangelogTypeHelper
    {
        private const string HISTORY_FIELD_STATUS = "status";
        private const string HISTORY_FIELD_FLAGGED = "Flagged";
        private const string HISTORY_FIELDTYPE_JIRA = "jira";
        private const string HISTORY_FIELDTYPE_CUSTOM = "custom";

        public bool IsFieldStatus(HistoryItemDto history)
            => history.Field.Equals(HISTORY_FIELD_STATUS)
            && history.Fieldtype.Equals(HISTORY_FIELDTYPE_JIRA);

        public bool IsFieldFlagged(HistoryItemDto history)
            => history.Field.Equals(HISTORY_FIELD_FLAGGED)
            && history.Fieldtype.Equals(HISTORY_FIELDTYPE_CUSTOM);
    }
}