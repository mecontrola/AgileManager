using MeControla.AgileManager.Core.Builders;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class IssuesToDeploySaveService : IIssuesToDeploySaveService
    {
        public readonly IDeployRepository deployRepository;
        public readonly IIssueRepository issueRepository;

        public IssuesToDeploySaveService(IDeployRepository deployRepository,
                                        IIssueRepository issueRepository)
        {
            this.deployRepository = deployRepository;
            this.issueRepository = issueRepository;
        }

        public async Task Save(IList<IssueDeployDto> list, CancellationToken cancellationToken)
        {
            foreach (var item in list)
                await Save(item, cancellationToken);
        }

        public async Task Save(IssueDeployDto item, CancellationToken cancellationToken)
        {
            var issue = await issueRepository.FindAsync(item.IssueId, cancellationToken);

            if (issue == null)
                return;

            var deploy = item.Id == Guid.Empty
                       ? BuldEntity()
                       : await deployRepository.FindAsync(item.Id, cancellationToken);

            deploy.IssueId = issue.Id;
            deploy.Services = item.Services;
            deploy.DeployedIn = item.DeployedIn;

            if (deploy.Id == 0)
                await deployRepository.CreateAsync(deploy, cancellationToken);
            else
                await deployRepository.UpdateAsync(deploy, cancellationToken);
        }

        private Deploy BuldEntity()
            => DeployBuilder.GetInstance()
                            .ToBuild();
    }
}