using NSubstitute;
using Stefanini.Core.TestingTools.NSubstitute;
using Stefanini.ViaReport.Core.Exceptions;
using Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using System;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class SessionGetMock
    {
        public static ISessionGet Create()
        {
            var mock = Substitute.For<ISessionGet>();
            mock.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                         Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                         Arg.Any<CancellationToken>())
                .Returns(SessionDtoMock.CreateByJson());

            return mock;
        }

        public static ISessionGet CreateWithJiraAuthenticationException()
            => CreateServiceExceptionBase<JiraAuthenticationException>();

        public static ISessionGet CreateWithJiraForbiddenException()
            => CreateServiceExceptionBase<JiraForbiddenException>();

        private static ISessionGet CreateServiceExceptionBase<T>()
            where T : Exception, new()
        {
            var mock = Substitute.For<ISessionGet>();
            mock.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                         Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                         Arg.Any<CancellationToken>())
                .TaskThrows(new T());

            return mock;
        }
    }
}