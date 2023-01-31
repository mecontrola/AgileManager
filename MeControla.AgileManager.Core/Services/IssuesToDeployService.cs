using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class IssuesToDeployService : IIssuesToDeployService
    {
        private readonly IIssueRepository issueRepository;

        private readonly IIssueDeployEntityToDtoMapper issueDeployEntityToDtoMapper;

        public IssuesToDeployService(IIssueRepository issueRepository,
                                    IIssueDeployEntityToDtoMapper issueDeployEntityToDtoMapper)
        {
            this.issueRepository = issueRepository;
            this.issueDeployEntityToDtoMapper = issueDeployEntityToDtoMapper;
        }

        public async Task<IList<IssueDeployDto>> Load(long projectId, CancellationToken cancellationToken)
        {
            var issues = await issueRepository.GetIssuesBackendToDeployAsync(projectId, cancellationToken);
            issues = issues.OrderByDescending(x => int.Parse(x.Key.OnlyNumbers())).ToList();

            return issueDeployEntityToDtoMapper.ToMapList(issues);
        }
    }
}