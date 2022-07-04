using Stefanini.ViaReport.Core.Exceptions;
using Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class JiraAuthService : IJiraAuthService
    {
        private readonly ISessionGet sessionGet;

        public JiraAuthService(ISessionGet sessionGet)
        {
            this.sessionGet = sessionGet;
        }

        public async Task<bool> IsAuthenticationOk(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                var sessionInfo = await sessionGet.Execute(username, password, cancellationToken);

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
            => sessionDto.LoginInfo.PreviousLoginTime > sessionDto.LoginInfo.LastFailedLoginTime;
    }
}