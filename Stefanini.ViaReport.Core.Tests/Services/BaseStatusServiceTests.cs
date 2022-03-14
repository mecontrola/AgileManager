using FluentAssertions;
using NSubstitute;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public abstract class BaseStatusServiceTests<T>
        where T : BaseStatusService
    {
        private readonly IBaseStatusService service;

        private readonly CancellationTokenSource cancellationTokenSource;

        public BaseStatusServiceTests()
        {
            var api = Substitute.For<IStatusGetAll>();
            api.Execute(Arg.Any<string>(),
                        Arg.Any<string>(),
                        Arg.Any<CancellationToken>())
               .Returns(StatusDtoMock.CreateListAll());

            service = (T)Activator.CreateInstance(typeof(T), new object[] { api });
            cancellationTokenSource = new CancellationTokenSource();
        }

        protected async Task RunTest(IDictionary<string, string> expected)
        {
            var actual = await service.GetList(string.Empty, string.Empty, cancellationTokenSource.Token);

            actual.Count.Should().Be(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}