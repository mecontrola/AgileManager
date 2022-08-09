using MeControla.Kernel.Settings;

namespace MeControla.Kernel.Tests.Mocks.Entities.Settings
{
    public class UserSettingsMock
    {
        public static UserSettings CreateEmpty()
            => new();

        public static UserSettings Create()
            => new()
            {
                Url = DataMock.TEXT_URL,
                Username = DataMock.VALUE_DEFAULT_TEXT,
                Password = DataMock.VALUE_DEFAULT_TEXT2
            };
    }
}