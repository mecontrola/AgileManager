using NSubstitute;
using Stefanini.Core.TestingTools.NSubstitute;
using Stefanini.ViaReport.Updater.Core.Exceptions;
using Stefanini.ViaReport.Updater.Core.Integrations.Github.Repos;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Dtos;
using System;
using System.Threading;

namespace Stefanini.ViaReport.Updater.Core.Tests.Mocks.Integrations.Github.Repos
{
    public class ReleasesLastestMock
    {
        public static IReleasesLastest Create()
        {

            var mock = Substitute.For<IReleasesLastest>();
            mock.Execute(Arg.Any<CancellationToken>())
                        .Returns(ReleaseDtoMock.Create());

            return mock;
        }

        public static IReleasesLastest CreateWithGithubException()
            => CreateServiceExceptionBase<GithubException>();

        private static IReleasesLastest CreateServiceExceptionBase<T>()
            where T : Exception, new()
        {
            var mock = Substitute.For<IReleasesLastest>();
            mock.Execute(Arg.Any<CancellationToken>())
                        .TaskThrows(new T());

            return mock;
        }
    }
}