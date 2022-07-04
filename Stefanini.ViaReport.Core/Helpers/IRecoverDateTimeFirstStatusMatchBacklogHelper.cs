using Stefanini.ViaReport.Data.Dtos.Jira;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IRecoverDateTimeFirstStatusMatchBacklogHelper
    {
        DateTime? GetDateTime(ChangelogDto changelog, IList<string> statuses);
    }
}