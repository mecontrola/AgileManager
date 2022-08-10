using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class StatusSchema
    {
        public static string Table { get; } = "am_status";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "stt";

        public static class Columns
        {
            public static string Id { get; } = nameof(Status.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(Status.Uuid).GetColumnName(PREFIX);
            public static string Key { get; } = nameof(Status.Key).GetColumnName(PREFIX);
            public static string Name { get; } = nameof(Status.Name).GetColumnName(PREFIX);
            public static string StatusCategoryId { get; } = StatusCategorySchema.Columns.Id;
        }
    }
}