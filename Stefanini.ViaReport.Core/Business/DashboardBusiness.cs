using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public class DashboardBusiness : IDashboardBusiness
    {
        private const int WEEKS_GROUP_BY = 2;
        private const int DAYS_REMOVE = 120;

        private readonly IIssuesResolvedInDateRangeService issuesResolvedInDateRangeService;
        private readonly IIssuesEpicByLabelService issuesEpicByLabelService;
        private readonly IGenerateWeeksFromRangeDateHelper generateWeeksFromRangeDateHelper;
        private readonly IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper;

        public DashboardBusiness(IIssuesResolvedInDateRangeService issuesResolvedInDateRangeService,
                                 IIssuesEpicByLabelService issuesEpicByLabelService,
                                 IGenerateWeeksFromRangeDateHelper generateWeeksFromRangeDateHelper,
                                 IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper)
        {
            this.issuesResolvedInDateRangeService = issuesResolvedInDateRangeService;
            this.issuesEpicByLabelService = issuesEpicByLabelService;
            this.generateWeeksFromRangeDateHelper = generateWeeksFromRangeDateHelper;
            this.issueDtoToIssueInfoDtoMapper = issueDtoToIssueInfoDtoMapper;
        }

        public async Task<DashboardDto> GetData(string username, string password, string project, CancellationToken cancellationToken)
        {
            var rangeDate = generateWeeksFromRangeDateHelper.GenerateList(DateTime.Now.AddDays(-DAYS_REMOVE), DateTime.Now, WEEKS_GROUP_BY);
            var data = await issuesResolvedInDateRangeService.GetData(username,
                                                                      password,
                                                                      project,
                                                                      rangeDate.Values.First().Item1,
                                                                      rangeDate.Values.Last().Item2,
                                                                      cancellationToken);

            return new()
            {
                Throughput = OrganizeThroughputData(rangeDate, data)
            };
        }

        private DashboardInfoDto OrganizeThroughputData(IDictionary<string, Tuple<DateTime, DateTime>> rangeDate, SearchDto data)
        {
            var list = rangeDate.Select(itm =>
            {
                var itens = data.Issues
                                .Where(issue => issue.Fields.Resolutiondate?.Date >= itm.Value.Item1.Date
                                             && issue.Fields.Resolutiondate?.Date <= itm.Value.Item2.Date)
                                .Select(issue => issueDtoToIssueInfoDtoMapper.ToMap(issue));

                return new DashboardInfoItemDto()
                {
                    Date = itm.Value.Item1,
                    Value = itens?.Count() ?? 0,
                    Issues = itens?.ToList() ?? Array.Empty<IssueInfoDto>().ToList()
                };
            });

            return new()
            {
                Average = data.Total / rangeDate.Count,
                Items = list.ToList()
            };
        }
    }
}