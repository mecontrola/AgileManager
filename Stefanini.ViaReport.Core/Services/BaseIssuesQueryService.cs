using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Dtos.Jira.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public abstract class BaseIssuesQueryService
    {
        private readonly ISearchPost searchPost;

        public BaseIssuesQueryService(ISearchPost searchPost)
            => this.searchPost = searchPost;

        protected async Task<SearchDto> RunCriterias(string username,
                                                     string password,
                                                     JqlBuilder criterias,
                                                     CancellationToken cancellationToken)
            => await searchPost.Execute(username, password, MountSearchData(criterias), cancellationToken);

        private static SearchInputDto MountSearchData(JqlBuilder criterias)
            => SearchInputDtoBuilder.GetInstance()
                                    .AddJql(criterias)
                                    .ToBuild();
    }
}