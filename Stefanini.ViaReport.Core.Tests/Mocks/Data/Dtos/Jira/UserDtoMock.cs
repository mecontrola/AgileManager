using Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
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