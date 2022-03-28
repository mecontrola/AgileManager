using Stefanini.ViaReport.Core.Data.Dto.Settings;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings
{
    public class AppSettingsDtoMock
    {
        public static AppSettingsDto CreateEmpty()
            => new();

        public static AppSettingsDto Create()
            => new()
            {
                Username = DataMock.VALUE_DEFAULT_TEXT,
                Password = DataMock.VALUE_DEFAULT_TEXT2,
                PersistFilter = false,
            };

        public static AppSettingsDto CreateWithCacheFilter()
            => new()
            {
                Username = DataMock.VALUE_DEFAULT_TEXT,
                Password = DataMock.VALUE_DEFAULT_TEXT2,
                PersistFilter = true,
                FilterData = AppFilterDtoMock.Create()
            };
    }
}