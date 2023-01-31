namespace MeControla.AgileManager.Core.Tests.Business
{
    //public class UpstreamDownstreamRateBusinessTests : BaseJiraApiTests
    //{
    //    private readonly IUpstreamDownstreamRateBusiness business;
    //
    //    public UpstreamDownstreamRateBusinessTests()
    //    {
    //        var weekOfTheYearFormatHelper = new WeekOfTheYearFormatHelper();
    //        var dateTimeFromStringHelper = new DateTimeFromStringHelper();
    //
    //        var calculateGrowthToDoInProgressHelper = new CalculateGrowthToDoInProgressHelper();
    //        var calculateUpstreamDownstreamRateHelper = new CalculateUpstreamDownstreamRateHelper(weekOfTheYearFormatHelper);
    //        var readCFDFileExportHelper = new ReadCFDFileExportHelper(dateTimeFromStringHelper);
    //
    //        business = new UpstreamDownstreamRateBusiness(calculateGrowthToDoInProgressHelper,
    //                                                      calculateUpstreamDownstreamRateHelper,
    //                                                      readCFDFileExportHelper);
    //    }
    //
    //    [Fact(DisplayName = "[UpstreamDownstreamRateBusiness.GetData] Deve recuperar a exportação do arquivo CSV referente ao indicador CFD e realizar o cálculo da Saúde do Backlog.")]
    //    public async Task Deve()
    //    {
    //        var expected = AHMInfoDtoMock.CreateCheckFile();
    //        var actual = await business.GetData(DataMock.FILENAMA_CFD_CSV_IMPORT, GetCancellationToken());
    //
    //        actual.Count.Should().Be(expected.Count);
    //        actual.Should().BeEquivalentTo(expected);
    //    }
    //}
}