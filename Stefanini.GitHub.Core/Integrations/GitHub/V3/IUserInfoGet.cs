using Stefanini.GitHub.Core.Data.Dto.GitHub;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.GitHub.Core.Integrations.GitHub.V3
{
    public interface IUserInfoGet
    {
        Task<UserInfoDto> Execute(string username, string password, CancellationToken cancellationToken);
    }
}