using NSubstitute;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class ProjectGetAllMock
    {
        public static IProjectGetAll Create()
        {
            var statusGetAll = Substitute.For<IProjectGetAll>();
            statusGetAll.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                                 Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                                 Arg.Any<CancellationToken>())
                        .Returns(ProjectDtoMock.CreateByJson());

            return statusGetAll;
        }
    }
}