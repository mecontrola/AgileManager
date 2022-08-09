using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class QuarterSchema
    {
        public static string Table { get; } = "am_quarter";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "qrt";

        public static class Columns
        {
            public static string Id { get; } = nameof(Quarter.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(Quarter.Uuid).GetColumnName(PREFIX);
            public static string Name { get; } = nameof(Quarter.Name).GetColumnName(PREFIX);
        }
    }
}