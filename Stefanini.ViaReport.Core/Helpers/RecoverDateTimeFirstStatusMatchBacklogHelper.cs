using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class RecoverDateTimeFirstStatusMatchBacklogHelper : IRecoverDateTimeFirstStatusMatchBacklogHelper
    {
        private const string HISTORY_FIELD_STATUS = "status";
        private const string HISTORY_FIELDTYPE_JIRA = "jira";

        public DateTime? GetDateTime(ChangelogDto changelog, IList<string> statuses)
        {
            var changelogs = GetChangeStatusInChangelog(changelog, statuses);

            return changelogs.Any()
                 ? changelogs.MinBy(itm => itm.Created).Created
                 : null;
        }

        private static IEnumerable<HistoryDto> GetChangeStatusInChangelog(ChangelogDto changelog, IList<string> statuses)
            => changelog.Histories
                        .Where(itm => itm.Items
                                         .Any(x => statuses.Any(statusId => IsJiraStatus(x)
                                                                         && x.To.Equals(statusId))));

        private static bool IsJiraStatus(HistoryItemDto history)
            => history.Field.Equals(HISTORY_FIELD_STATUS)
            && history.Fieldtype.Equals(HISTORY_FIELDTYPE_JIRA);
    }
}