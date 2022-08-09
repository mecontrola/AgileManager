using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class IssueStatusHistorySchema
    {
        public static string Table { get; } = "am_issue_status_history";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "ish";

        public static class Columns
        {
            public static string Id { get; } = nameof(IssueStatusHistory.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(IssueStatusHistory.Uuid).GetColumnName(PREFIX);
            public static string DateTime { get; } = nameof(IssueStatusHistory.DateTime).GetColumnName(PREFIX);
            public static string IssueId { get; } = IssueEpicSchema.Columns.Id;
            public static string StatusId { get; } = StatusSchema.Columns.Id;
        }
    }
}