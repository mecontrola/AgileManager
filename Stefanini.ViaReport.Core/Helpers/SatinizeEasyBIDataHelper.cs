using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dto.EasyBI;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class SatinizeEasyBIDataHelper : ISatinizeEasyBIDataHelper
    {
        private const string REGEX_DATETIME_KEY = "date";
        private const string REGEX_DATETIME = @"^W[0-9]{1,2},\s(?<date>.*)$";

        private readonly IGenerateWeeksFromRangeDateHelper generateWeeksFromRangeDateHelper;

        public SatinizeEasyBIDataHelper(IGenerateWeeksFromRangeDateHelper generateWeeksFromRangeDateHelper)
        {
            this.generateWeeksFromRangeDateHelper = generateWeeksFromRangeDateHelper;
        }

        public IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> Execute(ReportResultDto values)
        {
            var inProgressIndex = GetIndexByColumnName(values.QueryResults.ColumnPositions, EasyBIReportColumnName.InProgress.GetDescription());
            var toDoIndex = GetIndexByColumnName(values.QueryResults.ColumnPositions, EasyBIReportColumnName.ToDo.GetDescription());
            var doneIndex = GetIndexByColumnName(values.QueryResults.ColumnPositions, EasyBIReportColumnName.Done.GetDescription());

            return new Dictionary<EasyBIReportColumnName, IList<CFDInfoDto>>
                {
                    { EasyBIReportColumnName.ToDo, GetValues(values.QueryResults, toDoIndex) },
                    { EasyBIReportColumnName.InProgress, GetValues(values.QueryResults, inProgressIndex) },
                    { EasyBIReportColumnName.Done, GetValues(values.QueryResults, doneIndex) },
                };
        }

        private static int GetIndexByColumnName(IList<List<ReportResultColumnPositionDto>> columnPositions, string columnName)
            => columnPositions.Select((itm, index) => (itm, index))
                              .Where(elm => elm.itm.Any(itm => CheckItem(itm, columnName)))
                              .Select(x => x.index)
                              .DefaultIfEmpty(-1)
                              .First();

        private static IList<CFDInfoDto> GetValues(ReportResultQueryDto queryResults, int columnIndex)
            => queryResults.RowPositions.Select((itm, index) => new CFDInfoDto
            {
                Date = ConvertDateTimeFromString(itm[0].Name),
                Value = queryResults.Values[index][columnIndex]
            }).ToList();

        private static DateTime ConvertDateTimeFromString(string dateTime)
        {
            dateTime = GetDateFromString(dateTime);
            return string.IsNullOrWhiteSpace(dateTime)
                 ? DateTime.MinValue
                 : Convert.ToDateTime(dateTime);
        }

        private static bool CheckItem(ReportResultColumnPositionDto columnPosition, string columnName)
            => columnPosition.Name.Equals(columnName);

        private static string GetDateFromString(string dateTime)
        {
            var regex = Regex.Match(dateTime, REGEX_DATETIME);
            if (!regex.Success)
                return string.Empty;

            return regex.Groups[REGEX_DATETIME_KEY].Value;
        }
        //-----------------------------------------------------------------------------------------
        public IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> Execute(SearchDto result, IDictionary<StatusCategories, List<string>> statuses)
        {
            var iniDate = GetInitDate(result);
            var endDate = GetEndDate(result);
            var rangeDate = generateWeeksFromRangeDateHelper.GenerateList(iniDate, endDate);

            var issues = SatinizeIssueHistoryStatus(result, statuses[StatusCategories.InProgress]);
            
            return new Dictionary<EasyBIReportColumnName, IList<CFDInfoDto>>
                {
                    { EasyBIReportColumnName.ToDo, GetToDoValues(issues, rangeDate) },
                    { EasyBIReportColumnName.InProgress, GetInProgressValues(issues, rangeDate) },
                    { EasyBIReportColumnName.Done, GetDoneValues(issues, rangeDate) },
                };
        }

        private static IList<CFDInfoDto> GetToDoValues(IList<IssueStatusCategoryInitDate> issues, IDictionary<string, Tuple<DateTime, DateTime>> rangeDate)
            => MountValuesByStatusCategory(issues, rangeDate, IsToDo);

        private static IList<CFDInfoDto> GetInProgressValues(IList<IssueStatusCategoryInitDate> issues, IDictionary<string, Tuple<DateTime, DateTime>> rangeDate)
            => MountValuesByStatusCategory(issues, rangeDate, IsInProgress);

        private static IList<CFDInfoDto> GetDoneValues(IList<IssueStatusCategoryInitDate> issues, IDictionary<string, Tuple<DateTime, DateTime>> rangeDate)
            => MountValuesByStatusCategory(issues, rangeDate, IsDone);

        private static bool IsToDo(IssueStatusCategoryInitDate issue, Tuple<DateTime, DateTime> interval)
            =>
               ((!issue.Histories.ContainsKey(StatusCategories.InProgress) &&
                (IsValidInterval(issue.Histories[StatusCategories.ToDo], interval) || issue.Histories[StatusCategories.ToDo] < interval.Item1))
            || (issue.Histories.ContainsKey(StatusCategories.InProgress) &&
                IsValidInterval(interval.Item1, issue.Histories[StatusCategories.ToDo], issue.Histories[StatusCategories.InProgress]) &&
                IsValidInterval(interval.Item2, issue.Histories[StatusCategories.ToDo], issue.Histories[StatusCategories.InProgress]))
            || (issue.Histories.ContainsKey(StatusCategories.InProgress) &&
                IsValidInterval(issue.Histories[StatusCategories.ToDo], interval)));

        private static bool IsInProgress(IssueStatusCategoryInitDate issue, Tuple<DateTime, DateTime> interval)
            => issue.Histories.ContainsKey(StatusCategories.InProgress)
            && (!issue.Histories.ContainsKey(StatusCategories.Done) &&
                (IsValidInterval(issue.Histories[StatusCategories.InProgress], interval) || issue.Histories[StatusCategories.InProgress] < interval.Item1))
            || (issue.Histories.ContainsKey(StatusCategories.Done) &&
                IsValidInterval(interval.Item1, issue.Histories[StatusCategories.InProgress], issue.Histories[StatusCategories.Done]) &&
                IsValidInterval(interval.Item2, issue.Histories[StatusCategories.InProgress], issue.Histories[StatusCategories.Done]))
            || (issue.Histories.ContainsKey(StatusCategories.Done) &&
                IsValidInterval(issue.Histories[StatusCategories.InProgress], interval));

        private static bool IsDone(IssueStatusCategoryInitDate issue, Tuple<DateTime, DateTime> interval)
            => issue.Histories.ContainsKey(StatusCategories.Done)
            && issue.Histories[StatusCategories.Done].Date <= interval.Item2;

        private static IList<CFDInfoDto> MountValuesByStatusCategory(IList<IssueStatusCategoryInitDate> issues, IDictionary<string, Tuple<DateTime, DateTime>> rangeDate, Func<IssueStatusCategoryInitDate, Tuple<DateTime, DateTime>, bool> predicate)
            => rangeDate.Select(interval =>
            {
                var data = issues.Where(issue => predicate(issue, interval.Value));

                return new CFDInfoDto
                {
                    Date = interval.Value.Item1,
                    Value = data.Count(),
                    Issues = data.Select(val => val.IssueKey).ToArray()
                };
            }).ToList();

        private static DateTime GetInitDate(SearchDto result)
            => result.Issues
                     .Select(itm => itm.Fields.Created)
                     .Min();

        private static DateTime GetEndDate(SearchDto result)
            => result.Issues
                     .Where(itm => itm.Fields.Resolutiondate.HasValue)
                     .Select(itm => itm.Fields.Resolutiondate.Value)
                     .Max();

        private static IList<IssueStatusCategoryInitDate> SatinizeIssueHistoryStatus(SearchDto result, IList<string> inProgressStatuses)
            => result.Issues
                     .Select(issue => GenerateIssueStatusCategoryInitDate(issue, inProgressStatuses))
                     .ToList();

        private static IssueStatusCategoryInitDate GenerateIssueStatusCategoryInitDate(IssueDto issue, IList<string> inProgressStatuses)
        {
            var data = new IssueStatusCategoryInitDate
            {
                IssueKey = issue.Key,
                Histories = new Dictionary<StatusCategories, DateTime>
                {
                    { StatusCategories.ToDo, issue.Fields.Created }
                }
            };

            var inProgressDate = IssueInProgressDateInitialized(issue, inProgressStatuses);
            if (inProgressDate.HasValue)
                data.Histories.Add(StatusCategories.InProgress, inProgressDate.Value);

            if (issue.Fields.Resolutiondate.HasValue)
                data.Histories.Add(StatusCategories.Done, issue.Fields.Resolutiondate.Value);

            return data;
        }

        private static DateTime? IssueInProgressDateInitialized(IssueDto issue, IList<string> inProgressStatuses)
        {
            var changelogs = GetChangeStatusInChangelog(issue, inProgressStatuses);
            
            return changelogs.Any()
                 ? changelogs.MinBy(itm => itm.Created).Created
                 : null;
        }

        private static IEnumerable<HistoryDto> GetChangeStatusInChangelog(IssueDto issue, IList<string> inProgressStatuses)
            => issue.Changelog
                    .Histories
                    .Where(itm => itm.Items
                                     .Any(x => inProgressStatuses.Any(statusId => IsJiraStatus(x)
                                                                               && x.To.Equals(statusId))));

        private static bool IsJiraStatus(HistoryItemDto history)
            => history.Field.Equals("status")
            && history.Fieldtype.Equals("jira");

        private static bool IsValidInterval(DateTime value, Tuple<DateTime, DateTime> interval)
            => IsValidInterval(value, interval.Item1, interval.Item2);

        private static bool IsValidInterval(DateTime value, DateTime compare1, DateTime compare2)
            => value.Date >= compare1.Date
            && value.Date <= compare2.Date;
    }

    class IssueStatusCategoryInitDate
    {
        public string IssueKey { get; set; }
        public IDictionary<StatusCategories, DateTime> Histories { get; set; } = new Dictionary<StatusCategories, DateTime>();
    }
}