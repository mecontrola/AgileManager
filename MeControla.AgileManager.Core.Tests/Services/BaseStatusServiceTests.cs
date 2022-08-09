using FluentAssertions;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Statuses;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.TestingTools;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public abstract class BaseStatusServiceTests<T> : BaseAsyncMethods
        where T : BaseStatusService
    {
        private readonly IBaseStatusService service;

        public BaseStatusServiceTests()
        {
            var api = Substitute.For<IStatusGetAll>();
            api.Execute(Arg.Any<CancellationToken>())
               .Returns(StatusDtoMock.CreateListAll());

            service = (T)Activator.CreateInstance(typeof(T), new object[] { api });
        }

        protected async Task RunTest(IDictionary<string, string> expected)
        {
            var actual = await service.GetList(GetCancellationToken());

            actual.Count.Should().Be(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}