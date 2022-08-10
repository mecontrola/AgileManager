using MeControla.AgileManager.Core.Data.Dto;
using MeControla.AgileManager.Core.Helpers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public class UpstreamDownstreamRateBusiness : IUpstreamDownstreamRateBusiness
    {
        private readonly ICalculateGrowthToDoInProgressHelper calculateGrowthToDoInProgressHelper;
        private readonly ICalculateUpstreamDownstreamRateHelper calculateUpstreamDownstreamRateHelper;
        private readonly IReadCFDFileExportHelper readCFDFileExportHelper;

        public UpstreamDownstreamRateBusiness(ICalculateGrowthToDoInProgressHelper calculateGrowthToDoInProgressHelper,
                                              ICalculateUpstreamDownstreamRateHelper calculateUpstreamDownstreamRateHelper,
                                              IReadCFDFileExportHelper readCFDFileExportHelper)
        {
            this.calculateGrowthToDoInProgressHelper = calculateGrowthToDoInProgressHelper;
            this.calculateUpstreamDownstreamRateHelper = calculateUpstreamDownstreamRateHelper;
            this.readCFDFileExportHelper = readCFDFileExportHelper;
        }

        public async Task<IList<AHMInfoDto>> GetData(string filename, CancellationToken cancellationToken)
        {
            var values = await readCFDFileExportHelper.GetData(filename, cancellationToken);
            var processedValues = calculateGrowthToDoInProgressHelper.Execute(values);

            return calculateUpstreamDownstreamRateHelper.Execute(processedValues);
        }
    }
}