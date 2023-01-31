using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos.Inputs;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
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