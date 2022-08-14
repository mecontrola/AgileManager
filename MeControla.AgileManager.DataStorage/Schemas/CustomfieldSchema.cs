using MeControla.AgileManager.Data.Entities;
using MeControla.Kernel.Tools;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class CustomfieldSchema
    {
        private const string PREFIX_TABLE = "am";
        private const string PREFIX_COLUMN = "cfd";

        private static TableMetadata<Customfield> Metadata { get; } = new(PREFIX_TABLE, PREFIX_COLUMN);

        public static string Table { get; } = Metadata.GetTableName();
        public static string Schema { get; } = "agile_manager";

        public static class Columns
        {
            public static string Id { get; } = Metadata.GetColumnName(x => x.Id);
            public static string Uuid { get; } = Metadata.GetColumnName(x => x.Uuid);
            public static string Key { get; } = Metadata.GetColumnName(x => x.Key);
            public static string Name { get; } = Metadata.GetColumnName(x => x.Name);
            public static string Type { get; } = Metadata.GetColumnName(x => x.Type);
            public static string Custom { get; } = Metadata.GetColumnName(x => x.Custom);
            public static string Active { get; } = Metadata.GetColumnName(x => x.Active);
        }
    }
}