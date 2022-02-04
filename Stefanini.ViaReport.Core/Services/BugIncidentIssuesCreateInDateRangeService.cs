using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class BugIncidentIssuesCreateInDateRangeService : BaseIssuesInDateRangesService, IBugIncidentIssuesCreateInDateRangeService
    {
        private static readonly string[] LABELS_INCIDENTS = new string[] { "incidente", "Incidente" };

        public BugIncidentIssuesCreateInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override string[] CreateJql(string project, DateTime initDate, DateTime endDate)
            => new string[]
            {
                GetProjectCriteria(project),
                In(FIELD_LABELS, LABELS_INCIDENTS, itm => $"'{itm}'"),
                GetBetweenCreatedDateCriteria(initDate, endDate)
            };
    }
}