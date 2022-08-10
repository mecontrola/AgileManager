using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
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