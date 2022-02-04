using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Extensions;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public abstract class BaseIssuesQueryService
    {
        private const string CLAUSE_AND = " AND ";
        private const string CLAUSE_OR = " OR ";
        private const string CLAUSE_IN = " IN ";
        private const string CLAUSE_NOT_IN = " NOT IN ";

        protected const string FIELD_CREATED = "created";
        protected const string FIELD_RESOLVED = "resolved";
        protected const string FIELD_FIX_VERSION = "fixVersion";
        protected const string FIELD_LABELS = "labels";
        protected const string FIELD_STATUS = "status";
        protected const string FIELD_STATUS_CATEGORY = "statusCategory";

        private static readonly IssueTypes[] BASIC_ISSUE_TYPES = new[] { IssueTypes.Bug, IssueTypes.Task, IssueTypes.Epic, IssueTypes.Story, IssueTypes.TechnicalDebt };
        private static readonly StatusTypes[] DELETED_STATUSES = new[] { StatusTypes.Removed, StatusTypes.Cancelled };

        private readonly ISearchPost searchPost;

        public BaseIssuesQueryService(ISearchPost searchPost)
        {
            this.searchPost = searchPost;
        }

        protected async Task<SearchDto> RunCriterias(string username,
                                                     string password,
                                                     string[] criterias,
                                                     CancellationToken cancellationToken)
            => await searchPost.Execute(username, password, MountJql(criterias), cancellationToken);

        private static SearchInputDto MountJql(string[] criterias)
            => new()
            {
                Jql = string.Join(CLAUSE_AND, criterias).TrimAll(),
                StartAt = 0,
                MaxResults = 256,
                Fields = Array.Empty<string>()
            };

        protected static string GetProjectCriteria(string project)
            => Equal("project", project);

        protected static string GetIssueTypeCriteria(params IssueTypes[] issueTypes)
            => In("issuetype", issueTypes, issueType => $"{(int)issueType}");

        protected static string GetStatusCriteria(params StatusTypes[] statuses)
            => In(FIELD_STATUS, statuses, status => status.GetDescription());

        protected static string GetNotInDeletedStatusesCriteria()
            => GetNotInDeletedStatusesCriteria(Array.Empty<StatusTypes>());

        protected static string GetNotInDeletedStatusesCriteria(params StatusTypes[] statuses)
            => GetDeletedStatusesCriteria(CLAUSE_NOT_IN, statuses);

        protected static string GetInDeletedStatusesCriteria()
            => GetInDeletedStatusesCriteria(Array.Empty<StatusTypes>());

        protected static string GetInDeletedStatusesCriteria(params StatusTypes[] statuses)
            => GetDeletedStatusesCriteria(CLAUSE_IN, statuses);

        private static string GetDeletedStatusesCriteria(string @operator, StatusTypes[] statuses)
            => $"{FIELD_STATUS} {@operator} ({string.Join(',', DELETED_STATUSES.Union(statuses).Select(itm => itm.GetDescription()))})";

        protected static string GetInStatusCategoriesCriteria(params StatusCategories[] statuses)
            => GetInStatusCategoriesCriteria(CLAUSE_IN, statuses);

        protected static string GetNotInStatusCategoriesCriteria(params StatusCategories[] statuses)
            => GetInStatusCategoriesCriteria(CLAUSE_NOT_IN, statuses);

        private static string GetInStatusCategoriesCriteria(string @operator, StatusCategories[] statusCategories)
            => $"{FIELD_STATUS_CATEGORY} {@operator} ('{string.Join(',', statusCategories.Select(itm => itm.GetDescription()))}')";

        protected static string GetBetweenCreatedDateCriteria(DateTime initDate, DateTime endDate)
            => GetBetweenDatesCriteria(FIELD_CREATED, initDate, endDate);

        protected static string GetBetweenResolvedDateCriteria(DateTime initDate, DateTime endDate)
            => GetBetweenDatesCriteria(FIELD_RESOLVED, initDate, endDate);

        private static string GetBetweenDatesCriteria(string field, DateTime initDate, DateTime endDate)
            => And(GetIsGreaterEqualThan(field, initDate), GetIsLessEqualThan(field, endDate));

        protected static string GetBasicIssueTypesCriteria()
            => In("issuetype", BASIC_ISSUE_TYPES, itm => $"{(int)itm}");

        protected static string Equal(string field, string value)
            => $"{field} = '{value}'";

        protected static string In<T>(string field, T[] values)
            => In<T>(field, values, itm => itm.ToString());

        protected static string In<T>(string field, T[] values, Func<T, string> selector)
            => $"{field}{CLAUSE_IN}({string.Join(',', values.Select(selector))})";

        protected static string NotIn<T>(string field, T[] values)
            => NotIn<T>(field, values, itm => itm.ToString());

        protected static string NotIn<T>(string field, T[] values, Func<T, string> selector)
            => $"{field}{CLAUSE_NOT_IN}({string.Join(',', values.Select(selector))})";

        protected static string IsNull(string field)
            => $"{field} IS NULL";

        protected static string IsNotNull(string field)
            => $"{field} IS NOT NULL";

        protected static string And(params string[] criterias)
            => string.Join(CLAUSE_AND, criterias);

        protected static string Or(params string[] criterias)
            => $"(({string.Join($"){CLAUSE_OR}(", criterias)}))";

        protected static string GetIsLessThan(string field, DateTime initDate)
            => GetIsLessThan(field, DateFormat(initDate));

        protected static string GetIsLessThan(string field, string value)
            => $"{field} < {value}";

        protected static string GetIsLessEqualThan(string field, DateTime value)
            => GetIsLessEqualThan(field, DateFormat(value));

        protected static string GetIsLessEqualThan(string field, string value)
            => $"{field} <= {value}";

        protected static string GetIsGreaterEqualThan(string field, DateTime value)
            => GetIsGreaterEqualThan(field, DateFormat(value));

        protected static string GetIsGreaterEqualThan(string field, string value)
            => $"{field} >= {value}";

        private static string DateFormat(DateTime value)
            => $"'{value:yyyy-MM-dd}'";
    }
}