using MeControla.AgileManager.Data.Dtos.Jira;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface ICheckChangelogTypeHelper
    {
        bool IsFieldFlagged(HistoryItemDto history);
        bool IsFieldStatus(HistoryItemDto history);
    }
}