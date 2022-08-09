namespace MeControla.AgileManager.Core.Helpers
{
    public interface IMountJiraUrlHelper
    {
        string GetIssueUrl(string urlBase, string issueKey);
    }
}