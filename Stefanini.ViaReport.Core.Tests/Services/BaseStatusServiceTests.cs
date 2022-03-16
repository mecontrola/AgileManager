using FluentAssertions;
using NSubstitute;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public abstract class BaseStatusServiceTests<T> : BaseAsyncMethods
        where T : BaseStatusService
    {
        private readonly IBaseStatusService service;

        public BaseStatusServiceTests()
        {
            var api = Substitute.For<IStatusGetAll>();
            api.Execute(Arg.Any<string>(),
                        Arg.Any<string>(),
                        Arg.Any<CancellationToken>())
               .Returns(StatusDtoMock.CreateListAll());

            service = (T)Activator.CreateInstance(typeof(T), new object[] { api });
        }

        protected async Task RunTest(IDictionary<string, string> expected)
        {
            var actual = await service.GetList(string.Empty, string.Empty, GetCancellationToken());

            actual.Count.Should().Be(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}