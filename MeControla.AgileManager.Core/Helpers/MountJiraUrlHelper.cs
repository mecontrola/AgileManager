using System;

namespace MeControla.AgileManager.Core.Helpers
{
    public class MountJiraUrlHelper : IMountJiraUrlHelper
    {
        public string GetIssueUrl(string urlBase, string issueKey)
        {
            var uri = new Uri(urlBase);
            return $"{uri.Scheme}://{uri.Host}/browse/{issueKey}";
        }
    }
}