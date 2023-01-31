using MeControla.AgileManager.Integrations.Jira.Data.Dtos;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Data.Dtos
{
    public class UserDtoMock
    {
        public static UserDto Create()
            => new()
            {
                Self = DataMock.USER_SELF,
                EmailAddress = DataMock.USER_EMAILADDRESS,
                DisplayName = DataMock.USER_DISPLAYNAME,
                Active = true,
                TimeZone = DataMock.USER_TIMEZONE
            };
    }
}