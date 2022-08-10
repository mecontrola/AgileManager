using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using MeControla.AgileManager.Data.Dtos.Settings;

namespace MeControla.AgileManager.Core.Tests.Mocks.Entities.Settings
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