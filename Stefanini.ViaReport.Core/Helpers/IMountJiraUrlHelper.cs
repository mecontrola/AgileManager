namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IMountJiraUrlHelper
    {
        string GetIssueUrl(string urlBase, string issueKey);
    }
}