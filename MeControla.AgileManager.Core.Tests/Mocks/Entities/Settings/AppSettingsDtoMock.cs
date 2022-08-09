using MeControla.AgileManager.Data.Dtos.Settings;

namespace MeControla.AgileManager.Core.Tests.Mocks.Entities.Settings
{
    public class AppSettingsDtoMock
    {
        public static AppSettingsDto CreateEmpty()
            => new();

        public static AppSettingsDto Create()
            => new()
            {
                Url = DataMock.JIRA_HOST,
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                Cache = DataMock.VALUE_DEFAULT_9,
                PersistFilter = false,
            };

        public static AppSettingsDto CreateWithCacheFilter()
            => new()
            {
                Url = DataMock.JIRA_HOST,
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                PersistFilter = true,
                FilterData = AppFilterDtoMock.Create()
            };

        public static AppSettingsDto CreateWithEmptyUrl()
        {
            var dto = Create();
            dto.Url = string.Empty;
            return dto;
        }

        public static AppSettingsDto CreateWithEmptyUsername()
        {
            var dto = Create();
            dto.Username = string.Empty;
            return dto;
        }

        public static AppSettingsDto CreateWithEmptyPassword()
        {
            var dto = Create();
            dto.Password = string.Empty;
            return dto;
        }

        public static object CreateWithEmptyUrlAndUsername()
        {
            var dto = Create();
            dto.Url = string.Empty;
            dto.Username = string.Empty;
            return dto;
        }

        public static object CreateWithEmptyUrlAndPassword()
        {
            var dto = Create();
            dto.Url = string.Empty;
            dto.Password = string.Empty;
            return dto;
        }

        public static AppSettingsDto CreateWithEmptyUsernameAndPassword()
        {
            var dto = Create();
            dto.Username = string.Empty;
            dto.Password = string.Empty;
            return dto;
        }
    }
}