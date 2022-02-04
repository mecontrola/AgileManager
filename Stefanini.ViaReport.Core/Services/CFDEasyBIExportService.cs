using Stefanini.ViaReport.Core.Data.Dto.EasyBI;
using Stefanini.ViaReport.Core.Integrations.Jira.EasyBI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class CFDEasyBIExportService : ICFDEasyBIExportService
    {
        private const string ACCOUNT_ID = "50";
        private const string REPORT_ID = "4543";
        private const string REPORT_FORMAT = "json";

        private readonly ICFDExportReportIntegration cfdExportReportIntegration;

        public CFDEasyBIExportService(ICFDExportReportIntegration cfdExportReportIntegration)
            => this.cfdExportReportIntegration = cfdExportReportIntegration;

        public async Task<ReportResultDto> GetReportData(string username,
                                                         string password,
                                                         string projects,
                                                         DateTime initDate,
                                                         DateTime endDate,
                                                         CancellationToken cancellationToken)
        {
            var dates = SatinizeDateRange(initDate, endDate);
            var data = await cfdExportReportIntegration.Execute(username,
                                                                 password,
                                                                 ACCOUNT_ID,
                                                                 REPORT_ID,
                                                                 REPORT_FORMAT,
                                                                 projects,
                                                                 dates,
                                                                 cancellationToken);

            return FilterRangeDate(data, initDate, endDate);
        }

        private static ReportResultDto FilterRangeDate(ReportResultDto data, DateTime initDate, DateTime endDate)
        {
            var indexInRange = GetIndexesInRangeDate(data, initDate, endDate);

            return new()
            {
                CubeName = data.CubeName,
                Definition = data.Definition,
                LastImportAt = data.LastImportAt,
                ReportName = data.ReportName,
                QueryResults = new()
                {
                    ColumnPositions = data.QueryResults.ColumnPositions,
                    FormattedValues = FilterByIndex(data.QueryResults.FormattedValues, indexInRange),
                    RowPositions = FilterByIndex(data.QueryResults.RowPositions, indexInRange),
                    Values = FilterByIndex(data.QueryResults.Values, indexInRange)
                }
            };
        }

        private static int[] GetIndexesInRangeDate(ReportResultDto data, DateTime initDate, DateTime endDate)
        {
            var indexInRange = new List<int>();

            for (int i = 0, l = data.QueryResults.RowPositions.Count; i < l; i++)
                if (IsRangeValid(data.QueryResults.RowPositions[i][0].StartDate, initDate, endDate))
                    indexInRange.Add(i);

            return indexInRange.ToArray();
        }

        private static IList<T> FilterByIndex<T>(IList<T> data, int[] indexes)
        {
            var list = new List<T>();

            for (int i = 0, l = data.Count; i < l; i++)
                if (indexes.Any(index => index == i))
                    list.Add(data[i]);

            return list;
        }

        private static bool IsRangeValid(DateTime date, DateTime initDate, DateTime endDate)
            => date >= initDate && date <= endDate;

        private static string SatinizeDateRange(DateTime initDate, DateTime endDate)
            => $"[\"{string.Join("\",\"", new[] { initDate.Year, endDate.Year }.Distinct().Select(year => $"[Time].[{year}]"))}\"]";
    }
}