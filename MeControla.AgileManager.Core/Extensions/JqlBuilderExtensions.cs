using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using System;
using System.Linq;

namespace MeControla.AgileManager.Core.Extensions
{
    public static class JqlBuilderExtensions
    {
        private static readonly IssueTypes[] BASIC_ISSUE_TYPES = new[] { IssueTypes.Bug, IssueTypes.Task, IssueTypes.Epic, IssueTypes.Story, IssueTypes.TechnicalDebt };
        private static readonly StatusTypes[] DELETED_STATUSES = new[] { StatusTypes.Removed, StatusTypes.Cancelled };

        public static JqlBuilder AddBasicIssueTypesCriteria(this JqlBuilder builder)
            => builder.AddInIssueTypesCriteria(BASIC_ISSUE_TYPES);


        public static JqlBuilder AddNotInDeletedStatusesCriteria(this JqlBuilder builder)
            => builder.AddNotInDeletedStatusesCriteria(Array.Empty<StatusTypes>());

        public static JqlBuilder AddNotInDeletedStatusesCriteria(this JqlBuilder builder, params StatusTypes[] statuses)
            => builder.AddNotInStatusesCriteria(GetDeletedStatusesWithOthersStatus(statuses));

        public static JqlBuilder AddInDeletedStatusesCriteria(this JqlBuilder builder)
            => builder.AddInDeletedStatusesCriteria(Array.Empty<StatusTypes>());

        public static JqlBuilder AddInDeletedStatusesCriteria(this JqlBuilder builder, params StatusTypes[] statuses)
            => builder.AddInStatusesCriteria(GetDeletedStatusesWithOthersStatus(statuses));

        private static StatusTypes[] GetDeletedStatusesWithOthersStatus(StatusTypes[] statuses)
            => DELETED_STATUSES.Union(statuses).ToArray();
    }
}