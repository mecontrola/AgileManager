using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IRecoverDateTimeFirstStatusMatchBacklogHelper
    {
        DateTime? GetDateTime(ChangelogDto changelog, IList<string> statuses);
    }
}