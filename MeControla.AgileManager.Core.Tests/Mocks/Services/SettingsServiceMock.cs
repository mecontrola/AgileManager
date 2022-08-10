using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Configurations;
using MeControla.AgileManager.Core.Tests.Mocks.Entities.Settings;
using MeControla.AgileManager.Data.Dtos.Settings;
using NSubstitute;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class SettingsServiceMock
    {
        public static ISettingsService Create()
        {
            var mock = Substitute.For<ISettingsService>();
            mock.LoadDataAsync(Arg.Any<CancellationToken>())
                .Returns(AppSettingsDtoMock.Create());
            mock.SaveAuthenticationAsync(Arg.Any<string>(),
                                         Arg.Any<string>(),
                                         Arg.Any<string>(),
                                         Arg.Any<CancellationToken>())
                .Returns(true);
            mock.SavePreferencesAsync(Arg.Any<bool>(),
                                      Arg.Any<bool>(),
                                      Arg.Any<int>(),
                                      Arg.Any<CancellationToken>())
                .Returns(true);
            mock.SaveFilterDataAsync(Arg.Any<AppFilterDto>(), Arg.Any<CancellationToken>())
                .Returns(true);
            mock.IsAuthenticationDataValidAsync(Arg.Any<CancellationToken>())
                .Returns(true);
            mock.GetJiraConfiguration()
                .Returns(JiraConfigurationMock.Create());

            return mock;
        }
    }
}