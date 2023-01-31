using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public class DeployBusiness : IDeployBusiness
    {
        private readonly IIssuesToDeployService issuesToDeployService;
        private readonly IIssuesToDeploySaveService issuesToDeploySaveSerice;

        public DeployBusiness(IIssuesToDeployService issuesToDeployService, IIssuesToDeploySaveService issuesToDeploySaveSerice)
        {
            this.issuesToDeployService = issuesToDeployService;
            this.issuesToDeploySaveSerice = issuesToDeploySaveSerice;
        }

        public async Task<IList<IssueDeployDto>> GetList(long projectId, CancellationToken cancellationToken)
            => await issuesToDeployService.Load(projectId, cancellationToken);

        public async Task SaveList(IList<IssueDeployDto> list, CancellationToken cancellationToken)
            => await issuesToDeploySaveSerice.Save(list, cancellationToken);
    }
}