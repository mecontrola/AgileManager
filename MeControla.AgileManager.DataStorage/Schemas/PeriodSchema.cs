using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Tools;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class PeriodSchema
    {
        private const string PREFIX_TABLE = "am";
        private const string PREFIX_COLUMN = "prd";

        private static TableMetadata<Period> Metadata { get; } = new(PREFIX_TABLE, PREFIX_COLUMN);

        public static string Table { get; } = Metadata.GetTableName();
        public static string Schema { get; } = "agile_manager";

        public static class Columns
        {
            public static string Id { get; } = Metadata.GetColumnName(x => x.Id);
            public static string Uuid { get; } = Metadata.GetColumnName(x => x.Uuid);
            public static string Key { get; } = Metadata.GetColumnName(x => x.Key);
            public static string Type { get; } = Metadata.GetColumnName(x => x.Type);
            public static string Name { get; } = Metadata.GetColumnName(x => x.Name);
            public static string Initial { get; } = Metadata.GetColumnName(x => x.Initial);
            public static string Final { get; } = Metadata.GetColumnName(x => x.Final);
            public static string ProjectId { get; } = ProjectSchema.Columns.Id;
        }
    }
}