using MeControla.AgileManager.Core.Exceptions;
using MeControla.AgileManager.Core.Integrations.Jira.V1.Auth;
using MeControla.AgileManager.Data.Dtos.Jira;
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
            catch (JiraAuthenticationException)
            {
                return false;
            }
            catch (JiraForbiddenException)
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