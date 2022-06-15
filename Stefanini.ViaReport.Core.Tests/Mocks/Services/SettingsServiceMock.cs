using NSubstitute;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings;
using Stefanini.ViaReport.Data.Dtos.Settings;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
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
                                         Arg.Any<CancellationToken>())
                .Returns(true);
            mock.SavePreferencesAsync(Arg.Any<bool>(), Arg.Any<CancellationToken>())
                .Returns(true);
            mock.SaveFilterDataAsync(Arg.Any<AppFilterDto>(), Arg.Any<CancellationToken>())
                .Returns(true);
            mock.IsAuthenticationDataValidAsync(Arg.Any<CancellationToken>())
                .Returns(true);

            return mock;
        }
    }
}