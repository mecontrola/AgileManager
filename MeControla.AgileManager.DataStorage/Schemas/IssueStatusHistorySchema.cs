using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Tools;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class IssueStatusHistorySchema
    {
        private const string PREFIX_TABLE = "am";
        private const string PREFIX_COLUMN = "ish";

        private static TableMetadata<IssueStatusHistory> Metadata { get; } = new(PREFIX_TABLE, PREFIX_COLUMN);

        public static string Table { get; } = Metadata.GetTableName();
        public static string Schema { get; } = "agile_manager";

        public static class Columns
        {
            public static string Id { get; } = Metadata.GetColumnName(x => x.Id);
            public static string Uuid { get; } = Metadata.GetColumnName(x => x.Uuid);
            public static string DateTime { get; } = Metadata.GetColumnName(x => x.DateTime);
            public static string IssueId { get; } = IssueSchema.Columns.Id;
            public static string FromStatusId { get; } = Metadata.GetColumnName(x => x.FromStatusId);
            public static string ToStatusId { get; } = Metadata.GetColumnName(x => x.ToStatusId);
        }
    }
}