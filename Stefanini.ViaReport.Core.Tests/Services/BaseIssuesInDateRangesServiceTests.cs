using NSubstitute;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services;
using System;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public abstract class BaseIssuesInDateRangesServiceTests<T>
        where T : BaseIssuesInDateRangesService
    {
        private const string PROJECT = "project";

        private static readonly DateTime DATE_INI = new(2000, 1, 1);
        private static readonly DateTime DATE_END = new(2000, 12, 31);

        private readonly CancellationTokenSource cancellationTokenSource;

        private readonly IBaseIssuesInDateRangesService service;
        private readonly ISearchPost api;

        public BaseIssuesInDateRangesServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = (T)Activator.CreateInstance(typeof(T), new object[] { api });
            cancellationTokenSource = new CancellationTokenSource();
        }

        protected abstract string GetJqlExpected();

        protected void RunTest()
        {
            service.GetData(string.Empty, string.Empty, PROJECT, DATE_INI, DATE_END, cancellationTokenSource.Token);

            api.Received().Execute(Arg.Any<string>(),
                                   Arg.Any<string>(),
                                   Arg.Is<SearchInputDto>(x => x.Jql.Equals(GetJqlExpected())),
                                   Arg.Any<CancellationToken>());
        }
    }
}