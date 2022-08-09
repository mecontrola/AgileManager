using MeControla.AgileManager.Data.Enums;
using MeControla.Kernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.AgileManager.Core.Builders.Jira
{
    public sealed class JqlBuilder
    {
        private const string CLAUSE_AND = " AND ";
        private const string CLAUSE_OR = " OR ";
        private const string CLAUSE_IN = " IN ";
        private const string CLAUSE_NOT_IN = " NOT IN ";

        private const string RESERVED_WORD_ORDER_BY = " ORDER BY ";
        private const string RESERVED_WORD_IS_NULL = " IS NULL ";

        private const string FIELD_KEY = "key";
        private const string FIELD_CREATED = "created";
        private const string FIELD_UPDATED = "updated";
        private const string FIELD_RESOLVED = "resolved";
        private const string FIELD_FIX_VERSION = "fixVersion";
        private const string FIELD_ISSUE_TYPE = "issuetype";
        private const string FIELD_LABELS = "labels";
        private const string FIELD_PROJECT = "project";
        private const string FIELD_STATUS = "status";
        private const string FIELD_STATUS_CATEGORY = "statusCategory";

        private static readonly IssueTypes[] BASIC_ISSUE_TYPES = new[] { IssueTypes.Bug, IssueTypes.Task, IssueTypes.Epic, IssueTypes.Story, IssueTypes.TechnicalDebt };
        private static readonly StatusTypes[] DELETED_STATUSES = new[] { StatusTypes.Removed, StatusTypes.Cancelled };

        private IList<string> Criterias { get; set; }
        private string OrderBy { get; set; }

        private JqlBuilder()
        {
            Criterias = new List<string>();
            OrderBy = string.Empty;
        }

        public JqlBuilder AddResolvedIsNull()
            => AddIsNull(FIELD_RESOLVED);

        public JqlBuilder AddFixVersionIsNull()
            => AddIsNull(FIELD_FIX_VERSION);

        public JqlBuilder AddProjectCriteria(string project)
            => Equal(FIELD_PROJECT, project);

        public JqlBuilder AddLabelsCriteria(string[] labels)
            => In(FIELD_LABELS, labels, itm => $"'{itm}'");

        public JqlBuilder AddInIssueTypesCriteria(params IssueTypes[] issueTypes)
            => In(FIELD_ISSUE_TYPE, issueTypes, issueType => $"{(int)issueType}");

        public JqlBuilder AddNotInIssueTypesCriteria(params IssueTypes[] issueTypes)
            => NotIn(FIELD_ISSUE_TYPE, issueTypes, issueType => $"{(int)issueType}");

        public JqlBuilder AddStatusCriteria(params StatusTypes[] statuses)
            => In(FIELD_STATUS, statuses, status => status.GetDescription());

        public JqlBuilder AddCreatedIsLessThan(DateTime initDate)
            => AddIsLessThan(FIELD_CREATED, initDate);

        public JqlBuilder AddUpdatedIsGreaterEqualThan(DateTime dateTime)
            => AddIsGreaterEqualThan(FIELD_UPDATED, dateTime);

        public JqlBuilder AddBetweenCreatedDateCriteria(DateTime initDate, DateTime endDate)
            => AddBetweenDatesCriteria(FIELD_CREATED, initDate, endDate);

        public JqlBuilder AddBetweenResolvedDateCriteria(DateTime initDate, DateTime endDate)
            => AddBetweenDatesCriteria(FIELD_RESOLVED, initDate, endDate);

        public JqlBuilder AddNotInDeletedStatusesCriteria()
            => AddNotInDeletedStatusesCriteria(Array.Empty<StatusTypes>());

        public JqlBuilder AddNotInDeletedStatusesCriteria(params StatusTypes[] statuses)
            => AddDeletedStatusesCriteria(CLAUSE_NOT_IN, statuses);

        public JqlBuilder AddInDeletedStatusesCriteria()
            => AddInDeletedStatusesCriteria(Array.Empty<StatusTypes>());

        public JqlBuilder AddInDeletedStatusesCriteria(params StatusTypes[] statuses)
            => AddDeletedStatusesCriteria(CLAUSE_IN, statuses);

        private JqlBuilder AddDeletedStatusesCriteria(string @operator, StatusTypes[] statuses)
            => SetCriteria($"{FIELD_STATUS} {@operator} ({string.Join(',', DELETED_STATUSES.Union(statuses).Select(itm => itm.GetDescription()))})");

        public JqlBuilder AddNotInStatusCategoriesCriteria(params StatusCategories[] statuses)
            => AddInStatusCategoriesCriteria(CLAUSE_NOT_IN, statuses);

        private JqlBuilder AddInStatusCategoriesCriteria(string @operator, StatusCategories[] statusCategories)
            => SetCriteria($"{FIELD_STATUS_CATEGORY} {@operator} ('{string.Join("','", statusCategories.Select(itm => itm.GetDescription()))}')");

        public JqlBuilder AddBasicIssueTypesCriteria()
            => In(FIELD_ISSUE_TYPE, BASIC_ISSUE_TYPES, itm => $"{(int)itm}");

        private JqlBuilder Equal(string field, string value)
            => SetCriteria($"{field} = '{value}'");

        private JqlBuilder In<T>(string field, T[] values, Func<T, string> selector)
            => SetCriteria($"{field}{CLAUSE_IN}({string.Join(',', values.Select(selector))})");

        private JqlBuilder NotIn<T>(string field, T[] values, Func<T, string> selector)
            => SetCriteria($"{field}{CLAUSE_NOT_IN}({string.Join(',', values.Select(selector))})");

        private JqlBuilder AddBetweenDatesCriteria(string field, DateTime initDate, DateTime endDate)
            => AddAnd(build => build.AddIsGreaterEqualThan(field, initDate).AddIsLessEqualThan(field, endDate));

        private JqlBuilder AddIsLessThan(string field, DateTime initDate)
            => AddIsLessThan(field, DateFormat(initDate));

        private JqlBuilder AddIsLessThan(string field, string value)
            => SetCriteria($"{field} < {value}");

        private JqlBuilder AddIsLessEqualThan(string field, DateTime value)
            => AddIsLessEqualThan(field, DateFormat(value));

        private JqlBuilder AddIsLessEqualThan(string field, string value)
            => SetCriteria($"{field} <= {value}");

        private JqlBuilder AddIsGreaterEqualThan(string field, DateTime value)
            => AddIsGreaterEqualThan(field, DateFormat(value));

        private JqlBuilder AddIsGreaterEqualThan(string field, string value)
            => SetCriteria($"{field} >= {value}");

        private static string DateFormat(DateTime value)
            => $"'{value:yyyy-MM-dd}'";

        private JqlBuilder AddIsNull(string field)
            => SetCriteria($"{field} {RESERVED_WORD_IS_NULL}");

        private JqlBuilder SetCriteria(string value)
        {
            Criterias.Add(value);
            return this;
        }

        public JqlBuilder AddKeyOrderBy()
            => AddOrderBy(FIELD_KEY);

        private JqlBuilder AddOrderBy(string field)
            => SetOrderBy($"{RESERVED_WORD_ORDER_BY} {field}");

        private JqlBuilder SetOrderBy(string value)
        {
            OrderBy = value;
            return this;
        }

        public JqlBuilder AddOr(Func<JqlBuilder, JqlBuilder> function)
            => SetCriteria($"(({string.Join($"){CLAUSE_OR}(", function(GetInstance()).Criterias)}))");

        public JqlBuilder AddAnd(Func<JqlBuilder, JqlBuilder> function)
            => SetCriteria(string.Join(CLAUSE_AND, function(GetInstance()).Criterias));

        public string ToBuild()
            => $"{string.Join(CLAUSE_AND, Criterias)} {OrderBy}".TrimAll();

        public static JqlBuilder GetInstance()
            => new();
    }
}