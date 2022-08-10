using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public class QuarterBusiness : IQuarterBusiness
    {
        public readonly IQuarterService quarterService;

        public QuarterBusiness(IQuarterService quarterService)
        {
            this.quarterService = quarterService;
        }

        public async Task<IList<QuarterDto>> ListAllAsync(CancellationToken cancellationToken)
            => await quarterService.LoadAllAsync(cancellationToken);
    }
}