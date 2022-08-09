using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Extensions.DataStorage;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class IssueImpedimentSchema
    {
        public static string Table { get; } = "am_issue_impediment";
        public static string Schema { get; } = "agile_manager";

        private const string PREFIX = "isim";

        public static class Columns
        {
            public static string Id { get; } = nameof(IssueImpediment.Id).GetColumnName(PREFIX);
            public static string Uuid { get; } = nameof(IssueImpediment.Uuid).GetColumnName(PREFIX);
            public static string Start { get; } = nameof(IssueImpediment.Start).GetColumnName(PREFIX);
            public static string End { get; } = nameof(IssueImpediment.End).GetColumnName(PREFIX);
            public static string IssueId { get; } = IssueSchema.Columns.Id;
        }
    }
}