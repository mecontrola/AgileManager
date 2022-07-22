using NSubstitute;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Helpers
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