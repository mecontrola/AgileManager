using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class IssueExtraDataRepository : BaseAsyncRepository<IssueExtraData>, IIssueExtraDataRepository
    {
        public IssueExtraDataRepository(IDbAppContext context)
            : base(context, context.IssueExtraDatas)
        { }
    }
}