using FluentAssertions;
using NSubstitute;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Integrations.Jira;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Stefanini.ViaReport.Core.Tests.Mocks.Services;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Business
{
    public class UpstreamDownstreamRateBusinessTests : BaseJiraApiTests
    {
        private readonly IUpstreamDownstreamRateBusiness business;

        public UpstreamDownstreamRateBusinessTests()
        {
            var calculateGrowthToDoInProgressHelper = Substitute.For<ICalculateGrowthToDoInProgressHelper>();
            var calculateUpstreamDownstreamRateHelper = Substitute.For<ICalculateUpstreamDownstreamRateHelper>();

            var readCFDFileExportHelper = Substitute.For<IReadCFDFileExportHelper>();

            business = new UpstreamDownstreamRateBusiness(calculateGrowthToDoInProgressHelper,
                                                          calculateUpstreamDownstreamRateHelper,
                                                          readCFDFileExportHelper);
        }

        //[Fact(DisplayName = "[UpstreamDownstreamRateBusiness.GetPreData]")]
        public async Task Deve()
        {
            var expected = CFDtoMock.Create();
            var actual = await business.GetData(string.Empty,
                                                   GetCancellationToken());
        }
    }
}