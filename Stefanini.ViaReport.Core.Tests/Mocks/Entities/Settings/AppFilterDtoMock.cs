using Stefanini.ViaReport.Core.Data.Dto.Settings;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings
{
    public class AppFilterDtoMock
    {
        public static AppFilterDto Create()
            => new()
            {
                StartDate = DataMock.DATETIME_START_CYCLE,
                EndDate = DataMock.DATETIME_END_CYCLE,
                Project = JiraProjectDtoMock.Create(),
                Quarter = DataMock.TEXT_QUARTER_1_2000
            };
    }
}