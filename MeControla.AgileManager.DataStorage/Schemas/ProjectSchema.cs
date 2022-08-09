using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class ProjectSchema
    {
        public static string Table { get; } = "am_project";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "prj";

        public static class Columns
        {
            public static string Id { get; } = nameof(Project.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(Project.Uuid).GetColumnName(PREFIX);
            public static string Key { get; } = nameof(Project.Key).GetColumnName(PREFIX);
            public static string Name { get; } = nameof(Project.Name).GetColumnName(PREFIX);
            public static string Selected { get; } = nameof(Project.Selected).GetColumnName(PREFIX);
            public static string ProjectCategoryId { get; } = nameof(Project.ProjectCategoryId).GetColumnName(PREFIX);
        }
    }
}