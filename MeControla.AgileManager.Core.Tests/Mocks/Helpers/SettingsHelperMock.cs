using NSubstitute;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks.Entities.Settings;

namespace MeControla.AgileManager.Core.Tests.Mocks.Helpers
{
    public class SettingsHelperMock
    {
        public static ISettingsHelper Create()
        {
            var helper = Substitute.For<ISettingsHelper>();
            helper.Data.Returns(AppSettingsDtoMock.Create());

            return helper;
        }
    }
}