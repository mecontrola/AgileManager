using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class ProjectCategorySchema
    {
        public static string Table { get; } = "am_project_category";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "pjct";

        public static class Columns
        {
            public static string Id { get; } = nameof(ProjectCategory.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(ProjectCategory.Uuid).GetColumnName(PREFIX);
            public static string Key { get; } = nameof(ProjectCategory.Key).GetColumnName(PREFIX);
            public static string Name { get; } = nameof(ProjectCategory.Name).GetColumnName(PREFIX);
        }
    }
}