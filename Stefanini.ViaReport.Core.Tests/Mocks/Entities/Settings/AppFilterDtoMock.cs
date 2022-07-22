using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using Stefanini.ViaReport.Data.Dtos.Settings;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings
{
    public class AppFilterDtoMock
    {
        public static AppFilterDto Create()
            => new()
            {
                StartDate = DataMock.DATETIME_START_CYCLE,
                EndDate = DataMock.DATETIME_END_CYCLE,
                Project = ProjectDtoMock.CreateSearch(),
                Quarter = QuarterDtoMock.CreateQ12000(),
            };
    }
}