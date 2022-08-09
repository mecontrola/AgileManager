using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Updater.Core.Tests.Mocks.Data.Dtos.Jira.Inputs;
using NSubstitute;
using NSubstitute.Equivalency;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public abstract class BaseIssuesInDateRangesServiceTests<T> : BaseAsyncMethods
        where T : BaseIssuesInDateRangesService
    {
        private readonly IBaseIssuesInDateRangesService service;
        private readonly ISearchPost api;

        public BaseIssuesInDateRangesServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = (T)Activator.CreateInstance(typeof(T), new object[] { api });
        }

        protected abstract string GetJqlExpected();

        protected async Task RunTest()
        {
            await service.GetData(DataMock.TEXT_SEARCH_PROJECT,
                                  DataMock.DATETIME_FIRST_DAY_YEAR,
                                  DataMock.DATETIME_LAST_DAY_YEAR,
                                  GetCancellationToken());

            var expected = SearchInputDtoMock.CreateWithJqlCustom(GetJqlExpected());

            await api.Received().Execute(ArgEx.IsEquivalentTo(expected),
                                         Arg.Any<CancellationToken>());
        }
    }
}