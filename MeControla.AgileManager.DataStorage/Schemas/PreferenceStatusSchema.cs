using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Tools;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class PreferenceStatusSchema
    {
        private const string PREFIX_TABLE = "am";
        private const string PREFIX_COLUMN = "psc";

        private static TableMetadata<PreferenceStatus> Metadata { get; } = new(PREFIX_TABLE, PREFIX_COLUMN);

        public static string Table { get; } = Metadata.GetTableName();
        public static string Schema { get; } = "agile_manager";

        public static class Columns
        {
            public static string Id { get; } = Metadata.GetColumnName(x => x.Id);
            public static string Uuid { get; } = Metadata.GetColumnName(x => x.Uuid);
            public static string Name { get; } = Metadata.GetColumnName(x => x.Name);
            public static string Order { get; } = Metadata.GetColumnName(x => x.Order);
            public static string Progress { get; } = Metadata.GetColumnName(x => x.Progress);
            public static string StatusId { get; } = StatusSchema.Columns.Id;
            public static string ProjectId { get; } = ProjectSchema.Columns.Id;
        }
    }
}