using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Projects;
using NSubstitute;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class ProjectGetAllMock
    {
        public static IProjectGetAll Create()
        {
            var mock = Substitute.For<IProjectGetAll>();
            mock.Execute(Arg.Any<CancellationToken>())
                .Returns(ProjectDtoMock.CreateByJson());

            return mock;
        }
    }
}