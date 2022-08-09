using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public class DownstreamJiraIndicatorsBusiness : IDownstreamJiraIndicatorsBusiness
    {
        private readonly IDownstreamIndicatorsService downstreamIndicatorsService;
        private readonly IDownstreamJiraIndicatorsService downstreamJiraIndicatorsService;

        public DownstreamJiraIndicatorsBusiness(IDownstreamIndicatorsService downstreamIndicatorsService,
                                                IDownstreamJiraIndicatorsService downstreamJiraIndicatorsService)
        {
            this.downstreamIndicatorsService = downstreamIndicatorsService;
            this.downstreamJiraIndicatorsService = downstreamJiraIndicatorsService;
        }

        public async Task<DownstreamIndicatorDto> GetLocalIndicatorsAsync(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await downstreamIndicatorsService.GetData(projectId, initDate, endDate, cancellationToken);

        public async Task<DownstreamIndicatorDto> GetJiraIndicatorsAsync(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await downstreamJiraIndicatorsService.GetData(projectId, initDate, endDate, cancellationToken);
    }
}