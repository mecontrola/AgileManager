using Stefanini.Core.Settings;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings
{
    public class UserSettingsMock
    {
        public static UserSettings CreateEmpty()
            => new();

        public static UserSettings Create()
            => new()
            {
                Username = DataMock.VALUE_DEFAULT_TEXT,
                Password = DataMock.VALUE_DEFAULT_TEXT2
            };
    }
}