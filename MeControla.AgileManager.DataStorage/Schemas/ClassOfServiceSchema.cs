using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Tools;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class ClassOfServiceSchema
    {
        private const string PREFIX_TABLE = "am";
        private const string PREFIX_COLUMN = "cof";

        private static TableMetadata<ClassOfService> Metadata { get; } = new(PREFIX_TABLE, PREFIX_COLUMN);

        public static string Table { get; } = Metadata.GetTableName();
        public static string Schema { get; } = "agile_manager";

        public static class Columns
        {
            public static string Id { get; } = Metadata.GetColumnName(x => x.Id);
            public static string Uuid { get; } = Metadata.GetColumnName(x => x.Uuid);
            public static string Key { get; } = Metadata.GetColumnName(x => x.Key);
            public static string Name { get; } = Metadata.GetColumnName(x => x.Name);
        }
    }
}