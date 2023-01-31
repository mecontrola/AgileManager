using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Exceptions;
using MeControla.AgileManager.Integrations.Jira.Rest.V1.Auth;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class JiraAuthService : IJiraAuthService
    {
        private readonly ISessionGet sessionGet;

        public JiraAuthService(ISessionGet sessionGet)
        {
            this.sessionGet = sessionGet;
        }

        public async Task<bool> IsAuthenticationOk(CancellationToken cancellationToken)
        {
            try
            {
                var sessionInfo = await sessionGet.Execute(cancellationToken);

                return IsPreviousLoginTimeBiggerThenLastFailedLoginTime(sessionInfo);
            }
            catch (AuthenticationException)
            {
                return false;
            }
            catch (ForbiddenException)
            {
                return false;
            }
        }

        private static bool IsPreviousLoginTimeBiggerThenLastFailedLoginTime(SessionDto sessionDto)
            => !HasLoginInfo(sessionDto)
            || sessionDto.LoginInfo.PreviousLoginTime > sessionDto.LoginInfo.LastFailedLoginTime;

        private static bool HasLoginInfo(SessionDto sessionDto)
            => sessionDto.LoginInfo != null;
    }
}