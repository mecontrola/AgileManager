using NSubstitute;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class SearchPostMock
    {
        public static ISearchPost Create()
        {
            var issueGet = Substitute.For<ISearchPost>();
            issueGet.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                             Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                             Arg.Any<SearchInputDto>(),
                             Arg.Any<CancellationToken>())
                    .Returns(SearchDtoMock.CreateByJson());

            return issueGet;
        }
    }
}