using Stefanini.ViaReport.Data.Dtos.Jira;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class RecoverDateTimeFirstStatusMatchBacklogHelper : IRecoverDateTimeFirstStatusMatchBacklogHelper
    {
        private readonly ICheckChangelogTypeHelper checkChangelogTypeHelper;

        public RecoverDateTimeFirstStatusMatchBacklogHelper(ICheckChangelogTypeHelper checkChangelogTypeHelper)
        {
            this.checkChangelogTypeHelper = checkChangelogTypeHelper;
        }

        public DateTime? GetDateTime(ChangelogDto changelog, IList<string> statuses)
        {
            var changelogs = GetChangeStatusInChangelog(changelog, statuses);

            return changelogs.Any()
                 ? changelogs.MinBy(itm => itm.Created).Created
                 : null;
        }

        private IEnumerable<HistoryDto> GetChangeStatusInChangelog(ChangelogDto changelog, IList<string> statuses)
            => changelog.Histories
                        .Where(itm => itm.Items
                                         .Any(x => statuses.Any(statusId => checkChangelogTypeHelper.IsFieldStatus(x)
                                                                         && x.To.Equals(statusId))));
    }
}