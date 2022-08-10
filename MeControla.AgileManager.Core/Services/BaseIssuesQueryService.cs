using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Dtos.Jira.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public abstract class BaseIssuesQueryService
    {
        private readonly ISearchPost searchPost;

        public BaseIssuesQueryService(ISearchPost searchPost)
            => this.searchPost = searchPost;

        protected async Task<SearchDto> RunCriterias(JqlBuilder criterias, CancellationToken cancellationToken)
            => await searchPost.Execute(MountSearchData(criterias), cancellationToken);

        private static SearchInputDto MountSearchData(JqlBuilder criterias)
            => SearchInputDtoBuilder.GetInstance()
                                    .AddJql(criterias)
                                    .ToBuild();
    }
}