using Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface ICheckChangelogTypeHelper
    {
        bool IsFieldFlagged(HistoryItemDto history);
        bool IsFieldStatus(HistoryItemDto history);
    }
}