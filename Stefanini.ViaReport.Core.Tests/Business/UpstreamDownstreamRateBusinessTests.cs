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
            var issueGet = IssueGetMock.Create();
            var searchPost = SearchPostMock.Create();
            var statusGetAll = StatusGetAllMock.Create();
            var cfdExportReportIntegrationService = new CFDExportReportIntegrationService(searchPost);

            var satinizeEasyBIDataHelper = new SatinizeEasyBIDataHelper(new DateTimeFromStringHelper(),
                                                                        new GenerateWeeksFromRangeDateHelper());

            var cfdEasyBIExportService = Substitute.For<ICFDEasyBIExportService>();
            var calculateGrowthToDoInProgressHelper = Substitute.For<ICalculateGrowthToDoInProgressHelper>();
            var calculateUpstreamDownstreamRateHelper = Substitute.For<ICalculateUpstreamDownstreamRateHelper>();

            var readCFDFileExportHelper = Substitute.For<IReadCFDFileExportHelper>();

            business = new UpstreamDownstreamRateBusiness(cfdEasyBIExportService,
                                                          cfdExportReportIntegrationService,
                                                          calculateGrowthToDoInProgressHelper,
                                                          calculateUpstreamDownstreamRateHelper,
                                                          satinizeEasyBIDataHelper,
                                                          readCFDFileExportHelper,
                                                          issueGet,
                                                          statusGetAll);
        }

        //[Fact(DisplayName = "[UpstreamDownstreamRateBusiness.GetPreData]")]
        public async Task Deve()
        {
            var expected = CFDtoMock.Create();
            var actual = await business.GetPreData(DataMock.VALUE_USERNAME,
                                                   DataMock.VALUE_PASSWORD,
                                                   DataMock.TEXT_SEARCH_PROJECT,
                                                   GetCancellationToken());

            actual.Should().NotBeNull();
            actual.Should().ContainKeys(EasyBIReportColumnName.ToDo,
                                        EasyBIReportColumnName.InProgress,
                                        EasyBIReportColumnName.Done);
            actual[EasyBIReportColumnName.ToDo].Should().BeEquivalentTo(expected[EasyBIReportColumnName.ToDo], "To Do not equivalent.");
            actual[EasyBIReportColumnName.InProgress].Should().BeEquivalentTo(expected[EasyBIReportColumnName.InProgress], "In Progress not equivalent.");
            actual[EasyBIReportColumnName.Done].Should().BeEquivalentTo(expected[EasyBIReportColumnName.Done], "Done not equivalent.");
            actual.Should().BeEquivalentTo(expected);
        }
    }
}