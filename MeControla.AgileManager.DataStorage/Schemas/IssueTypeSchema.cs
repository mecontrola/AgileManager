using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class IssueTypeSchema
    {
        public static string Table { get; } = "am_issue_type";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "istp";

        public static class Columns
        {
            public static string Id { get; } = nameof(IssueType.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(IssueType.Uuid).GetColumnName(PREFIX);
            public static string Key { get; } = nameof(IssueType.Key).GetColumnName(PREFIX);
            public static string Name { get; } = nameof(IssueType.Name).GetColumnName(PREFIX);
        }
    }
}