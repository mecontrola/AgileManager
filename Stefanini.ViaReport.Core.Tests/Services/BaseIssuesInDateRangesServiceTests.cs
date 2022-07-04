using NSubstitute;
using NSubstitute.Equivalency;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Data.Dtos.Jira.Inputs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Tests.Services
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
            await service.GetData(DataMock.VALUE_USERNAME,
                                  DataMock.VALUE_PASSWORD,
                                  DataMock.TEXT_SEARCH_PROJECT,
                                  DataMock.DATETIME_FIRST_DAY_YEAR,
                                  DataMock.DATETIME_LAST_DAY_YEAR,
                                  GetCancellationToken());

            var expected = SearchInputDtoMock.CreateWithJqlCustom(GetJqlExpected());

            await api.Received().Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                                         Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                                         ArgEx.IsEquivalentTo(expected),
                                         Arg.Any<CancellationToken>());
        }
    }
}