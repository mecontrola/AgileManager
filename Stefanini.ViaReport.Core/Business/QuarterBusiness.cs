using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
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