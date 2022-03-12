using FluentAssertions;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class RecoverDateTimeFirstStatusMatchBacklogHelperTests
    {
        private const string ISSUE_KEY_SEA_217 = "SEA-217";

        private readonly IRecoverDateTimeFirstStatusMatchBacklogHelper helper;

        public RecoverDateTimeFirstStatusMatchBacklogHelperTests()
        {
            helper = new RecoverDateTimeFirstStatusMatchBacklogHelper();
        }

        [Fact(DisplayName = "[RecoverDateTimeFirstStatusMatchBacklogHelper] Deve retornar a primeira ocorrência de status existente no backlog de uma issue.")]
        public void DeveRetornarPrimeiraStatusListaFornecida()
        {
            var expected = DataMock.DATETIME_CHANGELOG_STATUS;
            var actual = helper.GetDateTime(GetChangelog(), GetStatuses());

            actual.Should().NotBeNull();
            actual.Value.Should().Be(expected);
        }

        private static IList<string> GetStatuses()
            => StatusDtoMock.CreateListInProgress()
                            .Select(x => x.Id)
                            .ToList();

        private static ChangelogDto GetChangelog()
            => IssueDtoMock.CreateIssueByJson(ISSUE_KEY_SEA_217)
                           .Changelog;
    }
}