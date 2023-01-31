using MeControla.AgileManager.Integrations.Jira.Data.Dtos;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface ICheckChangelogTypeHelper
    {
        bool IsFieldFlagged(HistoryItemDto history);
        bool IsFieldStatus(HistoryItemDto history);
    }
}