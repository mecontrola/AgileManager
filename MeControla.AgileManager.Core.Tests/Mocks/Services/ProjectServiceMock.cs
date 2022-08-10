using NSubstitute;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using System.Linq;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class ProjectServiceMock
    {
        public static IProjectService Create()
        {
            var mock = Substitute.For<IProjectService>();
            mock.LoadAllAsync(Arg.Any<CancellationToken>())
                .Returns(ProjectDtoMock.CreateList());
            mock.LoadSelectedAsync(Arg.Any<CancellationToken>())
                .Returns(ProjectDtoMock.CreateListSelected());
            mock.LoadSelectedIdsAsync(Arg.Any<CancellationToken>())
                .Returns(DataMock.PROJECTS);
            mock.SetSelectedByIdAsync(Arg.Any<long[]>(),
                                     Arg.Any<CancellationToken>())
                .Returns(callContext =>
                {
                    var key = callContext.ArgAt<long[]>(0);
                    return Enumerable.SequenceEqual(DataMock.PROJECTS, key); ;
                });

            return mock;
        }
    }
}