using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class IssueSchema
    {
        public static string Table { get; } = "am_issue";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "iss";

        public static class Columns
        {
            public static string Id { get; } = nameof(Issue.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(Issue.Uuid).GetColumnName(PREFIX);
            public static string Key { get; } = nameof(Issue.Key).GetColumnName(PREFIX);
            public static string Summary { get; } = nameof(Issue.Summary).GetColumnName(PREFIX);
            public static string Incident { get; } = nameof(Issue.Incident).GetColumnName(PREFIX);
            public static string Created { get; } = nameof(Issue.Created).GetColumnName(PREFIX);
            public static string Updated { get; } = nameof(Issue.Updated).GetColumnName(PREFIX);
            public static string Resolved { get; } = nameof(Issue.Resolved).GetColumnName(PREFIX);
            public static string Link { get; } = nameof(Issue.Link).GetColumnName(PREFIX);
            public static string Labels { get; } = nameof(Issue.Labels).GetColumnName(PREFIX);
            public static string ProjectId { get; } = ProjectSchema.Columns.Id;
            public static string StatusId { get; } = StatusSchema.Columns.Id;
            public static string IssueTypeId { get; } = IssueTypeSchema.Columns.Id;
        }
    }
}