using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class IssueEpicSchema
    {
        public static string Table { get; } = "am_issue_epic";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "isep";

        public static class Columns
        {
            public static string Id { get; } = nameof(IssueEpic.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(IssueEpic.Uuid).GetColumnName(PREFIX);
            public static string Progress { get; } = nameof(IssueEpic.Progress).GetColumnName(PREFIX);
            public static string IssueId { get; } = IssueSchema.Columns.Id;
            public static string QuarterId { get; } = QuarterSchema.Columns.Id;
        }
    }
}