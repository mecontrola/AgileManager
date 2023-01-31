using MeControla.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.AgileManager.Integrations.Jira.Builders
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

        public JqlBuilder AddInIssueTypesCriteria<T>(params T[] issueTypes)
            where T : struct, Enum
            => In(FIELD_ISSUE_TYPE, issueTypes, issueType => $"{(int)Enum.Parse(typeof(T), issueType.ToString())}");

        public JqlBuilder AddNotInIssueTypesCriteria<T>(params T[] issueTypes)
            where T : struct, Enum
            => NotIn(FIELD_ISSUE_TYPE, issueTypes, issueType => $"{(int)Enum.Parse(typeof(T), issueType.ToString())}");

        public JqlBuilder AddStatusCriteria<T>(params T[] statuses)
            where T : struct, Enum
            => In(FIELD_STATUS, statuses, status => GetEnumValue(status));

        public JqlBuilder AddCreatedIsLessThan(DateTime initDate)
            => AddIsLessThan(FIELD_CREATED, initDate);

        public JqlBuilder AddUpdatedIsGreaterEqualThan(DateTime dateTime)
            => AddIsGreaterEqualThan(FIELD_UPDATED, dateTime);

        public JqlBuilder AddBetweenCreatedDateCriteria(DateTime initDate, DateTime endDate)
            => AddBetweenDatesCriteria(FIELD_CREATED, initDate, endDate);

        public JqlBuilder AddBetweenResolvedDateCriteria(DateTime initDate, DateTime endDate)
            => AddBetweenDatesCriteria(FIELD_RESOLVED, initDate, endDate);

        public JqlBuilder AddInStatusesCriteria<T>(params T[] statuses)
            where T : struct, Enum
            => AddInStatusesCriteria(CLAUSE_IN, statuses);

        public JqlBuilder AddNotInStatusesCriteria<T>(params T[] statuses)
            where T : struct, Enum
            => AddInStatusesCriteria(CLAUSE_NOT_IN, statuses);

        private JqlBuilder AddInStatusesCriteria<T>(string @operator, T[] statuses)
            where T : struct, Enum
            => SetCriteria($"{FIELD_STATUS} {@operator} ('{string.Join("','", statuses.Select(itm => GetEnumValue(itm)))}')");

        public JqlBuilder AddInStatusCategoriesCriteria<T>(params T[] statuses)
            where T : struct, Enum
            => AddInStatusCategoriesCriteria(CLAUSE_IN, statuses);

        public JqlBuilder AddNotInStatusCategoriesCriteria<T>(params T[] statuses)
            where T : struct, Enum
            => AddInStatusCategoriesCriteria(CLAUSE_NOT_IN, statuses);

        private JqlBuilder AddInStatusCategoriesCriteria<T>(string @operator, T[] statusCategories)
            where T : struct, Enum
            => SetCriteria($"{FIELD_STATUS_CATEGORY} {@operator} ('{string.Join("','", statusCategories.Select(itm => GetEnumValue(itm)))}')");

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

        private static string GetEnumValue<T>(T value)
            where T : struct, Enum
            => string.IsNullOrWhiteSpace(value.GetDescription())
             ? value.ToString()
             : value.GetDescription();

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