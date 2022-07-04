using Stefanini.ViaReport.Data.Dtos.Settings;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings
{
    public class AppSettingsDtoMock
    {
        public static AppSettingsDto CreateEmpty()
            => new();

        public static AppSettingsDto Create()
            => new()
            {
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                PersistFilter = false,
            };

        public static AppSettingsDto CreateWithCacheFilter()
            => new()
            {
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                PersistFilter = true,
                FilterData = AppFilterDtoMock.Create()
            };

        public static AppSettingsDto CreateWithEmptyUsername()
            => new()
            {
                Username = string.Empty,
                Password = DataMock.VALUE_PASSWORD,
                PersistFilter = false,
            };

        public static AppSettingsDto CreateWithEmptyPassword()
            => new()
            {
                Username = DataMock.VALUE_USERNAME,
                Password = string.Empty,
                PersistFilter = false,
            };

        public static AppSettingsDto CreateWithEmptyUsernameAndPassword()
            => new()
            {
                Username = string.Empty,
                Password = string.Empty,
                PersistFilter = false,
            };
    }
}