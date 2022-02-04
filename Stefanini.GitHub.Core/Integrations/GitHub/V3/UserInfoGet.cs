using Stefanini.GitHub.Core.Data.Configurations;
using Stefanini.GitHub.Core.Data.Dto.GitHub;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.GitHub.Core.Integrations.Routes.GitHubRoutes.UserInfo;

namespace Stefanini.GitHub.Core.Integrations.GitHub.V3
{
    public class UserInfoGet : BaseGitHubIntegration, IUserInfoGet
    {
        public UserInfoGet(IGitHubConfiguration gitHubConfiguration)
            : base(gitHubConfiguration, JsonNamingPolicy.CamelCase)
        { }

        public async Task<UserInfoDto> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = route.INFO_GET;

            return await GetAsync<UserInfoDto>(username, password, cancellationToken);
        }
    }
}