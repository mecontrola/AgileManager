using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class DownstreamIndicatorsService : IDownstreamIndicatorsService
    {
        private readonly IIssueRepository issueRepository;

        private readonly IIssueEntityToDtoMapper issueEntityToDtoMapper;

        public DownstreamIndicatorsService(IIssueRepository issueRepository,
                                           IIssueEntityToDtoMapper issueEntityToDtoMapper)
        {
            this.issueRepository = issueRepository;
            this.issueEntityToDtoMapper = issueEntityToDtoMapper;
        }

        public async Task<DownstreamIndicatorDto> GetData(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => new()
            {
                CycleBalance = await GetCycleBalance(projectId, initDate, endDate, cancellationToken),
                Bugs = await GetIndicatorsByIssueType(IssueTypes.Bug, projectId, initDate, endDate, cancellationToken),
                TechnicalDebit = await GetIndicatorsByIssueType(IssueTypes.TechnicalDebt, projectId, initDate, endDate, cancellationToken),
            };

        private async Task<decimal> GetCycleBalance(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await issueRepository.GetCycleBalanceAsync(projectId, initDate, endDate, cancellationToken);

        private async Task<IDictionary<DownstreamIndicatorTypes, IList<IssueDto>>> GetIndicatorsByIssueType(IssueTypes issueType, long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => new Dictionary<DownstreamIndicatorTypes, IList<IssueDto>>
            {
                { DownstreamIndicatorTypes.Created, await GetCreatedByIssueType(issueType, projectId, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Opened, await GetOpenedByIssueType(issueType, projectId, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Existed, await GetExistedByIssueType(issueType, projectId, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Resolved, await GetResolvedByIssueType(issueType, projectId, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.CreatedAndResolved, await GetCreatedAndResolvedByIssueType(issueType, projectId, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Cancelled, await GetCancelledByIssueType(issueType, projectId, initDate, endDate, cancellationToken) },
            };

        private async Task<IList<IssueDto>> GetCreatedByIssueType(IssueTypes issueType, long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var list = await issueRepository.GetIssuesCreatedInDateRangeByIssueTypeAsync(issueType, projectId, initDate, endDate, cancellationToken);

            return issueEntityToDtoMapper.ToMapList(list);
        }

        private async Task<IList<IssueDto>> GetOpenedByIssueType(IssueTypes issueType, long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var list = await issueRepository.GetIssuesOpenedInDateRangeByIssueTypeAsync(issueType, projectId, initDate, endDate, cancellationToken);

            return issueEntityToDtoMapper.ToMapList(list);
        }

        private async Task<IList<IssueDto>> GetExistedByIssueType(IssueTypes issueType, long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var list = await issueRepository.GetIssuesExistedInDateRangeByIssueTypeAsync(issueType, projectId, initDate, endDate, cancellationToken);

            return issueEntityToDtoMapper.ToMapList(list);
        }

        private async Task<IList<IssueDto>> GetResolvedByIssueType(IssueTypes issueType, long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var list = await issueRepository.GetIssuesResolvedInDateRangeByIssueTypeAsync(issueType, projectId, initDate, endDate, cancellationToken);

            return issueEntityToDtoMapper.ToMapList(list);
        }

        private async Task<IList<IssueDto>> GetCreatedAndResolvedByIssueType(IssueTypes issueType, long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var list = await issueRepository.GetIssuesCreatedAndResolvedInDateRangeByIssueTypeAsync(issueType, projectId, initDate, endDate, cancellationToken);

            return issueEntityToDtoMapper.ToMapList(list);
        }

        private async Task<IList<IssueDto>> GetCancelledByIssueType(IssueTypes issueType, long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var list = await issueRepository.GetIssuesCancelledInDateRangeByIssueTypeAsync(issueType, projectId, initDate, endDate, cancellationToken);

            return issueEntityToDtoMapper.ToMapList(list);
        }
    }
}