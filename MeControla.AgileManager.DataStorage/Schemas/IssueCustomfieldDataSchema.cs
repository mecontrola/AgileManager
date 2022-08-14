using MeControla.AgileManager.Data.Entities;
using MeControla.Kernel.Tools;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal class IssueCustomfieldDataSchema
    {
        private const string PREFIX_TABLE = "am";
        private const string PREFIX_COLUMN = "isep";

        private static TableMetadata<IssueCustomfieldData> Metadata { get; } = new(PREFIX_TABLE, PREFIX_COLUMN);

        public static string Table { get; } = Metadata.GetTableName();
        public static string Schema { get; } = "agile_manager";

        public static class Columns
        {
            public static string Id { get; } = Metadata.GetColumnName(x => x.Id);
            public static string Uuid { get; } = Metadata.GetColumnName(x => x.Uuid);
            public static string Value { get; } = Metadata.GetColumnName(x => x.Value);
            public static string CustomfieldId { get; } = CustomfieldSchema.Columns.Id;
            public static string IssueId { get; } = IssueSchema.Columns.Id;
        }
    }
}