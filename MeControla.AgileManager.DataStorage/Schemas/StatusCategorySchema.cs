using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class StatusCategorySchema
    {
        public static string Table { get; } = "am_status_category";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "stct";

        public static class Columns
        {
            public static string Id { get; } = nameof(StatusCategory.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(StatusCategory.Uuid).GetColumnName(PREFIX);
            public static string Key { get; } = nameof(StatusCategory.Key).GetColumnName(PREFIX);
            public static string Name { get; } = nameof(StatusCategory.Name).GetColumnName(PREFIX);
        }
    }
}