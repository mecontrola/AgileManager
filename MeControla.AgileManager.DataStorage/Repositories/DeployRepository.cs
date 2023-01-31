using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class DeployRepository : BaseAsyncRepository<Deploy>, IDeployRepository
    {
        public DeployRepository(IDbAppContext context)
            : base(context, context.Deploys)
        { }
    }
}