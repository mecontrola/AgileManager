using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Tools;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class IssueExtraDataSchema
    {
        private const string PREFIX_TABLE = "am";
        private const string PREFIX_COLUMN = "ied";

        private static TableMetadata<IssueExtraData> Metadata { get; } = new(PREFIX_TABLE, PREFIX_COLUMN);

        public static string Table { get; } = Metadata.GetTableName();
        public static string Schema { get; } = "agile_manager";

        public static class Columns
        {
            public static string Id { get; } = IssueSchema.Columns.Id;
            public static string Uuid { get; } = Metadata.GetColumnName(x => x.Uuid);
            public static string StoryPoints { get; } = Metadata.GetColumnName(x => x.StoryPoints);
            public static string Impediment { get; } = Metadata.GetColumnName(x => x.Impediment);
            public static string CustomerLeadTime { get; } = Metadata.GetColumnName(x => x.CustomerLeadTime);
            public static string DiscoveryLeadTime { get; } = Metadata.GetColumnName(x => x.DiscoveryLeadTime);
            public static string SystemLeadTime { get; } = Metadata.GetColumnName(x => x.SystemLeadTime);
            public static string ClassOfServiceId { get; } = ClassOfServiceSchema.Columns.Id;
        }
    }
}